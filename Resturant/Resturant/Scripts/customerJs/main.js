jQuery(document).ready(function ($) {
    var cartWrapper = $('.cd-cart-container');

    //product id - you don't need a counter in your real project but you can use your real product id
    var productId = 0;
    var itemId = 0;

    if (productId == 0) {
        addItems();
    }
    if (cartWrapper.length > 0) {
        //store jQuery objects
        var cartBody = cartWrapper.find('.body')
        var cartList = cartBody.find('ul').eq(0);
        var cartTotal = cartWrapper.find('.checkout').find('span');
        var cartTrigger = cartWrapper.children('.cd-cart-trigger');
        var cartCount = cartTrigger.children('.count')
        var addToCartBtn = $('.cd-add-to-cart');


        //add product to cart
        addToCartBtn.on('click', function (event) {
            event.preventDefault();
            addToCart($(this));
        });

        //open/close cart
        cartTrigger.on('click', function (event) {
            event.preventDefault();
            toggleCart();
        });

        //close cart when clicking on the .cd-cart-container::before (bg layer)
        cartWrapper.on('click', function (event) {
            if ($(event.target).is($(this))) toggleCart(true);
        });

        //delete an item from the cart
        cartList.on('click', '.delete-item', function (event) {
            event.preventDefault();
            removeProduct($(event.target).parents('.product'));
        });

        //update item quantity
        cartList.on('change', 'select', function (event) {
            quickUpdateCart();
        });
    }

    function toggleCart(bool) {

        var cartIsOpen = (typeof bool === 'undefined') ? cartWrapper.hasClass('cart-open') : bool;

        if (cartIsOpen) {

            cartWrapper.removeClass('cart-open');


            cartList.find('.deleted').remove();

            setTimeout(function () {
                cartBody.scrollTop(0);
                //check if cart empty to hide it
                if (Number(cartCount.find('li').eq(0).text()) == 0) cartWrapper.addClass('empty');
            }, 500);
        } else {

            cartWrapper.addClass('cart-open');
        }
    }

    function addToCart(trigger) {
        var cartIsEmpty = cartWrapper.hasClass('empty');
        //update cart product list
        addProduct();
        //update number of items 
        updateCartCount(cartIsEmpty);
        //update total price
        updateCartTotal(trigger.data('price'), true);
        //show cart
        cartWrapper.removeClass('empty');
        quickUpdateCart();
    }

    function addProduct() {
        //this is just a product placeholder
        //you should insert an item with the selected product info
        //replace productId, productName, price and url with your real product infohttp:
        productId = productId + 1;
        var text = document.getElementById("mob").innerHTML
        var sp = text.split(",", 3)
        var productAdded = $('<li class="product"><div class="product-image"><a href="#0"><img src="../Content/images/product-preview.png" alt="placeholder"></a></div><div class="product-details"><h3><a href="#0">' + sp[0] + '</a></h3><span class="price">' + sp[1] + '</span><div class="actions"><p hidden id="' + sp[0] + sp[1] + '">' + productId + '</p><a href="#0" onClick="deleteItem()" class="delete-item">Delete</a><div class="quantity"><label for="cd-product-' + productId + '">Qty</label><span class="select"><select id="cd-product-' + productId + '" name="quantity"><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select></span></div></div></div></li>');
        cartList.prepend(productAdded);

        $.ajax({
            dataType: "json",
            type: "GET",
            url: 'http://localhost:11632/Home/AddItems?',
            contentType: "application/json; charset=utf-8",
            data: { name: sp[0], price: sp[1] },
            success: function (response) {
            },
            error: function (response) { alert(response); }

        });
    }

    //testing
    function addItems() {
        alert("b");
        $.ajax({
            dataType: "json",
            type: "GET",
            url: 'http://localhost:11632/Home/getItems?',
            contentType: "application/json; charset=utf-8",
            data: { Test: "mob" },
            success: function (response) {
                if (response != null) {
                    productId = productId + 1;
                    $.each(response, function (value, key) {
                        var options = '<option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option>';
                        var splittedoptions = options.split('value="' + key.Quantitity + '"');
                        var final = splittedoptions[0] + 'selected ' + 'value="' + key.Quantitity + '"' + splittedoptions[1];
                        var productAdded = $('<li class="product"><div class="product-image"><a href="#0"><img src="../Content/images/product-preview.png" alt="placeholder"></a></div><div class="product-details"><h3><a href="#0">' + key.Name + '</a></h3><span class="price">' + key.price + '</span><div class="actions"><p hidden id="' + key.Name + key.price + '">' + productId + '</p><a href="#0" class="delete-item">Delete</a><div class="quantity"><label for="cd-product-' + productId + '">Qty</label><span class="select"><select id="cd-product-' + productId + '" name="quantity">' + final + '</select></span></div></div></div></li>');
                        cartList.prepend(productAdded);
                        updateCartCount(true, key.Quantitity);
                        //update total price
                        updateCartTotal(key.price, true);
                        //show cart
                        cartWrapper.removeClass('empty');
                        oldquickUpdateCart();
                    });
                }

            },
            error: function (response) { alert(response); }

        });
    }
    function oldquickUpdateCart() {
        var quantity = 0;
        var price = 0;
        var quantities = "";
        cartList.children('li:not(.deleted)').each(function () {
            var singleQuantity = Number($(this).find('select').val());
            quantities = quantities + singleQuantity + ",";
            quantity = quantity + singleQuantity;
            price = price + singleQuantity * Number($(this).find('.price').text().replace('$', ''));
        });
        cartTotal.text(price.toFixed(2));
        cartCount.find('li').eq(0).text(quantity);
        cartCount.find('li').eq(1).text(quantity + 1);
    }
    function removeProduct(product) {


        cartList.find('.deleted').remove();

        var id = product[0].innerText
        var s = id.split("DeleteQty");

        var topPosition = product.offset().top - cartBody.children('ul').offset().top,
			productQuantity = Number(product.find('.quantity').find('select').val()),
			productTotPrice = Number(product.find('.price').text().replace('$', '')) * productQuantity;

        product.css('top', topPosition + 'px').addClass('deleted');
        $.ajax({
            dataType: "json",
            type: "GET",
            url: 'http://localhost:11632/Home/DeleteItem?',
            contentType: "application/json; charset=utf-8",
            data: { name: s[0] },
            success: function (response) {
            },
            error: function (response) { alert(response); }

        });
        //update items count + total price
        updateCartTotal(productTotPrice, false);
        updateCartCount(true, -productQuantity);


        //wait 8sec before completely remove the item
    }

    function quickUpdateCart() {
        var quantity = 0;
        var price = 0;
        var quantities = "";
        cartList.children('li:not(.deleted)').each(function () {
            var singleQuantity = Number($(this).find('select').val());
            quantities = quantities + singleQuantity + ",";
            quantity = quantity + singleQuantity;
            price = price + singleQuantity * Number($(this).find('.price').text().replace('$', ''));
        });
        $.ajax({
            dataType: "json",
            type: "GET",
            url: 'http://localhost:11632/Home/UpdateItemQuantities?',
            contentType: "application/json; charset=utf-8",
            data: { Quantities: quantities },
            success: function (response) {
            },
            error: function (response) { alert(response); }

        });
        cartTotal.text(price.toFixed(2));
        cartCount.find('li').eq(0).text(quantity);
        cartCount.find('li').eq(1).text(quantity + 1);
    }

    function updateCartCount(emptyCart, quantity) {
        if (typeof quantity === 'undefined') {
            var actual = Number(cartCount.find('li').eq(0).text()) + 1;
            var next = actual + 1;

            if (emptyCart) {
                cartCount.find('li').eq(0).text(actual);
                cartCount.find('li').eq(1).text(next);
            } else {
                cartCount.addClass('update-count');

                setTimeout(function () {
                    cartCount.find('li').eq(0).text(actual);
                }, 150);

                setTimeout(function () {
                    cartCount.removeClass('update-count');
                }, 200);

                setTimeout(function () {
                    cartCount.find('li').eq(1).text(next);
                }, 230);
            }
        } else {
            var actual = Number(cartCount.find('li').eq(0).text()) + quantity;
            var next = actual + 1;

            cartCount.find('li').eq(0).text(actual);
            cartCount.find('li').eq(1).text(next);
        }
    }

    function updateCartTotal(price, bool) {
        bool ? cartTotal.text((Number(cartTotal.text()) + Number(price)).toFixed(2)) : cartTotal.text((Number(cartTotal.text()) - Number(price)).toFixed(2));
    }
});
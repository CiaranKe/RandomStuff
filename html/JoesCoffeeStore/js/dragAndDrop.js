/**
 localStorage:   persistent between sessions.
 Spans browser windows and tabs.
 per domain.

 sessionStorage: deleted after browser close.
 Not shared between tabs or browser windows.
 **/

function addDnDHandlers() {
    var coffeeImages = document.getElementsByClassName("productarticlewide");
    var shoppingCartDZ = document.getElementById("shoppingCart");
    var shoppingCart = document.querySelectorAll("#shoppingCart ul")[0];
    var currentCart = null;

    //constructor function
    var Cart = (function()
    {
        this.coffees = [];
    });

    //constructor function
    var Coffee = (function(id, price)
    {
       this.coffeeID = id;
       this.price = price;
    });

    //check local storage for existing cart
    currentCart = JSON.parse(localStorage.getItem('cart'));

    if (!currentCart)
    {
        createEmptyCart();
    }

    updateShoppingCartUI();
    currentCart.addCoffee = function(coffee)
    {
        this.coffees.push(coffee);
        localStorage.setItem('cart', JSON.stringify(this));
    };

    for (var i = 0; i < coffeeImages.length; i++ )
    {
        coffeeImages[i].addEventListener('dragstart', function(ev)
        {
            ev.dataTransfer.effectAllowed = 'copy';
            ev.dataTransfer.setData("Text", this.getAttribute('id'));
        }, false);
    }

    shoppingCartDZ.addEventListener('dragover', function(ev)
    {
        if(ev.preventDefault)
        {
            ev.preventDefault();
        }
        ev.dataTransfer.dropEffect = 'copy';
        return false;
    }, false);

    shoppingCartDZ.addEventListener('drop', function(ev)
    {
        if (ev.stopPropagation)
        {
            ev.stopPropagation();
        }
        var coffeeId = ev.dataTransfer.getData('Text');
        var element = document.getElementById(coffeeId);

        addCoffeeToShoppingCart(element, coffeeId);
        ev.stopPropagation();

        return false;
    }, false);

    function addCoffeeToShoppingCart(item, id)
    {
        var price = item.getAttribute('data-price');
        var coffee = new Coffee(id, price);
        currentCart.addCoffee(coffee);
        updateShoppingCartUI();
    }

    function createEmptyCart()
    {
        localStorage.clear();
        localStorage.setItem('cart', JSON.stringify(new Cart()));
        currentCart = JSON.parse(localStorage.getItem('cart'));
    }

    function updateShoppingCartUI()
    {
        shoppingCart.innerHTML = "";
        for (var i = 0; i < currentCart.coffees.length; i++)
        {
            var liElement = document.createElement('li');
            liElement.innerHTML = currentCart.coffees[i].coffeeID + " " + currentCart.coffees[i].price;
            shoppingCart.appendChild(liElement);
        }
    }
}
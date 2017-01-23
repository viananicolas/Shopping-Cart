function CartDetailViewModel(model) {
    var self = this;

    self.sending = ko.observable(false);
    self.cart = model;

    for (var i = 0; i < self.cart.cartItems.length; i++) {
        self.cart.cartItems[i].quantity = ko.observable(self.cart.cartItems[i].quantity)
            .extend({ subTotal: self.cart.cartItems[i].book.salePrice });
    }
    self.cart.cartItems = ko.observableArray(self.cart.cartItems);

    self.cart.total = self.cart.cartItems.total();

    self.cartItemBeingChanged = null;

    self.deleteCartItem = function(cartItem) {
        self.sending(true);

        self.cartItemBeingChanged = cartItem;

        $.ajax({
            url: '/api/cartitems',
            type: 'delete',
            contentType: 'application/json',
            data: ko.toJSON(cartItem),
            success: self.successfulDelete,
            error: self.errorSave,
            complete: function() { self.sending(false) }
        });
    };

    self.sucessfulDelete = function(data) {
        $('.body-content')
            .prepend('<div class="alert alert-sucess"><strong>Sucesso!</strong> O item foi deletado do carrinho.</div>');

        self.cart.cartItems.remove(self.cartItemBeingChanged);

        cartSummaryViewModel.deleteCartItem(ko.JS(self.cartItemBeingChanged));
        self.cartItemBeingChanged = null;
    };
    self.errorSave = function() {
        $('.body-content')
            .prepend('<div class="alert alert-danger"><strong>Erro!</strong> Houve um erro ao atualizar o carrinho.</div>');
    };
    self.fadeOut=function(element) {
        $(element)
            .fadeOut(1000,
                function() {
                    $(element).remove();
                });
    }
}
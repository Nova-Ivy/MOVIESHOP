function GetCartCount() {
    $.ajax({
        type: 'post',
        url: '/Order/GetCartCount',
        dataType: 'json',

        success: function (count) {
            $('#cartCount').html(count);
        }
    })
}

GetCartCount();

function AddToCart(movieId) {
        $.ajax({
            type: 'post',
            url: '/Order/AddToCart',
            dataType: 'json',
            data: { id: movieId },
            success: function (count) {
                $('#cartCount').html(count);
            }
        })
}

function PlusItem(movieId) {
    $.ajax({
        type: 'post',
        url: '/Order/PlusItem',
        dataType: 'json',
        data: { id: movieId },
        success: function () {
            location.reload();
        }
    })
}

function MinusItem(movieId) {
    $.ajax({
        type: 'post',
        url: '/Order/MinusItem',
        dataType: 'json',
        data: { id: movieId },
        success: function () {
            location.reload();

        }
    })
}

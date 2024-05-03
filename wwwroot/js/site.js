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

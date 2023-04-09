
// document ready
$(document).ready(function () {
    getcategorieslistname();
    getCartCount();
});

// lay danh sach loai
function getcategorieslistname() {
    $.ajax({
        url: '/Categories/getCatListName',
        type: 'get',
        success: function (data) {
            // console.log(data);
            var str = '';
            for (var i in data) {
                str += '<a href="" class="nav-item nav-link">' + data[i].name + '</a>';
            };
            document.getElementById('id_categories').innerHTML = str;
        }
    })
}

// lay so luong trong gio hang
function getCartCount() {
    $.ajax({
        url: '/Cart/GetCartCount',
        type: 'get',
        async: true,
        success: function (data) {
            $('#cart_count').text(data);
        }
    })
}

// them 1 vao gio
function Add1toCart(id) {
    $.ajax({
        url: '/Cart/AddToCart',
        type: 'post',
        async: true,
        data: {
            productid: id,
            quantity: 1
        },
        success: function () {
            getCartCount();
            DisplayAdded();
        }
    })
}

// hien thong bao them vao gio
function DisplayAdded() {
    $('#added-to-cart').show();
    setTimeout(function () {
        $('#added-to-cart').hide();
    }, 2000);
}
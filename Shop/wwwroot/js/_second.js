
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

// hien thong bao them vao gio
function DisplayAdded() {
    $('#added-to-cart').show();
    setTimeout(function () {
        $('#added-to-cart').hide();
    }, 2000);
}

// Dang nhap
function Login() {
    var name = $('#login_name').val()
    var password = $('#login_password').val()
    $.ajax({
        url: '/Auth/TaskLogin',
        type: 'post',
        async: true,
        data: {
            name: name,
            password: password
        },
        success: function (data) {
            if (data == true) {
                window.location.href = '/';
            }
            else {
                $('#login_error').show();
            }
        }
    })
}

// lay so luong trong gio hang
function getCartCount() {
    $.ajax({
        url: '/Cart/GetCartCount',
        type: 'get',
        success: function (data) {
            $('#cart_count').text(data);
        }
    })
}


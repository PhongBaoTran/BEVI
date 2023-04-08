
// document ready
$(document).ready(function () {
    getcategorieslistname();
});

// lay danh sach loai
function getcategorieslistname() {
    $.ajax({
        url: 'Categories/getCatListName',
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
$(function () {
    //订单详情显示隐藏
    $(".toggle_detail").off("click").on("click", function () {
        $(".detail_hide").slideToggle();
        $(this).toggleClass("active");
        // return false;
    });
    //购物车钻石详情
    $(".ringdetail_show").off('click').on('click', function () {
        $(this).parent().parent().find(".ringdetail_hide").children("div").slideToggle();
        $(this).toggleClass("active");
        // return false;
    });

    //全选,非全选
    $(".check_all").off("click").on("click", function () {

        $(".shoppingcart_table").find("input").attr("checked", 'true');
        number1();
    });

    //计算选择的共有多少商品
    function number1() {
        var data = new Array();
        var number = 0;
        var total_price = 0;
        $('input:checkbox').each(function () {
            if (this.checked == true) {
                var num = $(this).val();
                if (num != '') {
                    number = parseInt($(this).val()) + parseInt(number);
                    total_price = parseFloat($(this).attr('data-price')) + parseFloat(total_price);
                }

            }

        });
        $("#cart-number strong").html(number); //选中的数量
        $("#cart-amount strong").html('&yen;' + total_price); //选择商品的价格
    }

    //复选框
    $(".shoppingcart_table tbody input").off("click").on("click", function () {
        var ifcheck = $(this).is(":checked");
        number1();
        var allcheck = $(".shoppingcart_table tbody input").length;
        var checkit = $(".shoppingcart_table tbody input[type='checkbox']:checked").length;

        if (ifcheck == false) {
            $(".check_all").attr("checked", false);
        }
        if (allcheck == checkit) {
            $(".check_all").attr("checked", true);
        }
    });

});


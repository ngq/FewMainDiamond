
$(function () {

    //显示更多地址
    $(".address_other").off('click').on('click', function () {
        $(this).parent().parent().find(".address_hide").fadeIn(300);
        // return false;
    });
    //选择收货地址
    $(".order_address .address_list input").off('change').on('change', function () {
        var phone = $(this).parent().find('.address_phone').html();
        $('.msg_r label').html(phone);
        $(".address_list").removeClass("select");
        $(this).parent().parent().addClass("select");

        // return false;
    });

    $(".address_add").on("click", function () {
        var index = layer.open({
            type: 1,
            title: false,
            closeBtn: 0,
            shift: 0,
            area: ["700px", "460px"],
            content: $(".address_edit")
        });
        $(".address_close").off('click').on('click', function () {
            layer.close(index);
            
        });
    });

    //配送地址
    $('.distribution').off('click').on('click', function () {
        $('#mobile').removeClass('error_info');
        $('#verify').hide();
        var username = $('#username').val();
        var address = $('#address').val();
        var province = $('#province').val();
        var city = $('#city').val();
        var distrct = $('#distrct').val();
        var postcode = $('#postcode').val();
        var mobile = $('#mobile').val();
        if ($.trim(username) == '' || $.trim(address) == '' || $.trim(province) == '' || $.trim(city) == '' || $.trim(distrct) == '' || $.trim(mobile) == '') {
            alert('信息填写不完整');
            return false;
        }

        if (!checkMobile(mobile)) {
            $('#mobile').addClass('error_info');
            $('#verify').show();
            return false;
        }

        $.post(addressSaveUrl, $('#address-form').serialize(), function (res) {
            var successMsg = new Popping().init({
                content: res.massge,
                hideTime: 2000
            });

            window.location.href = addressSaveUrl;
        });
    });

    
    //修改送货通知
    $(".msg_others,.msg_change").off('change').on('change', function () {
        $(".msg_r").css("display", "none");
        $(".msg_o").css("display", "block");
        // return false;
    });

    //修改送货通知
    $(".delivery_notic input[type='radio']").off('click').on('click', function () {
        var receipt = $('.delivery_notic').find('input[type="radio"]:checked').data('type');
        if (receipt == 1) {
            var address_phone = $('.address_list input:radio:checked').next().find('span').html();
            $('.msg_r label').html(address_phone);
        }
    });


    $(".msg_change").off('click').on('click', function () {
        $(".msg_r").css("display", "none");
        $(".msg_o").css("display", "block");
        // return false;
    });
    //如果没有收货人的时候，没有维护其他联系人,直接显示输入框和确认按钮
    if ($(".msg_receiver").data('addr') != 'have') {
        $(".msg_r").css("display", "none");
        $(".msg_o").css("display", "block");
        // return false;
        $(".msg_receiver").off('change').on('change', function () {
            $(".msg_r").css("display", "none");
            $(".msg_o").css("display", "block");
            // return false;
        });
        // $(".msg_confirm").off('click').on('click',function(){
        // 	$(".msg_r").css("display","none");
        // 	$(".msg_o").css("display","block");
        // 	// return false;
        // });
    }

    $(".msg_receiver").off('change').on('change', function () {
        $(".msg_r").css("display", "block");
        $(".msg_o").css("display", "none");
        // return false;
    });

    $(".msg_confirm").off('click').on('click', function () {
        var mobile = $('#receipt-phone').val();
        if (!checkMobile(mobile)) {
            alert('请输入有效的手机号码！');
            return false;
        }
        $(".msg_o").css("display", "none");
        $('.msg_r label').html(mobile);
        $(".msg_r").css("display", "block");


        // return false;
    });





   
    //立即结算固定
    $(window).scroll(function () {
        fixbottom();
    }).resize(function () {
        fixbottom();
    });
   

});
function fixbottom() {
    
    var drcps = $('.top_zhibao').offset().top;
    var wh = $(window).height();
    var st = $(window).scrollTop() + wh;
    if (st < drcps + 15) {
        $('.pay_bottom').addClass("pay_float");
    } else {
        $('.pay_bottom').removeClass("pay_float");
    }
}


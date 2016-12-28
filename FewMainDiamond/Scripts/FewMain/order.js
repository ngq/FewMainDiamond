
$(function () {
    //订单详情显示隐藏
    $(".toggle_detail").off("click").on("click", function () {
        $(".detail_hide").slideToggle();
        $(this).toggleClass("active");
        // return false;
    });
    //选择付款方式tab
    //		$("#tab1").off('click').on('click',function(){
    //			$(this).addClass("active").siblings().removeClass("active");
    //			$("#tab_content1").fadeIn().siblings().css("display","none");
    //			return false;
    //		});
    //		$("#tab2").off('click').on('click',function(){
    //			$(this).addClass("active").siblings().removeClass("active");
    //			$("#tab_content2").fadeIn().siblings().css("display","none");
    //			return false;
    //		});

    //选择付款方式tab
    $("#tab1").off('click').on('click', function () {
        $(this).addClass("active").siblings().removeClass("active");
        $("#tab_content1").fadeIn().siblings('#tab_content2').css("display", "none");
        return false;
    });
    $("#tab2").off('click').on('click', function () {
        $(this).addClass("active").siblings().removeClass("active");
        $("#tab_content2").fadeIn().siblings('#tab_content1').css("display", "none");
        return false;
    });

    //删除购物车中的商品
    $('.car-del').click(function () {
        var id = $(this).data('id');
        var _this = $(this);
        if (confirm('确定删除吗')) {
            var flag = true;
        } else {
            var flag = false;
        }
        if (flag == true) {
            $.get(cartDeleteUrl.replace(':id', id), { ajax: 1 }, function (res) {
                if (typeof (res) != 'object') {
                    alert('未登录');
                }
                if (res.data.number <= 0) {
                    window.location.reload();
                }
                _this.parent().parent().parent().parent().remove();
                $("#cart-amount strong").html('&yen;' + parseFloat(res.data.price)); //总价格
                $("#cart-number strong").text(res.data.number); //总数量
            });
        }
    });

    //添加所有到收藏
    $('#addAll').click(function () {
        var id = [];
        $('.addCollect').each(function (i) {
            id[i] = $(this).data('id');
        });

        if (confirm('确定加入收藏夹吗？')) {
            var flag = true;
        } else {
            var flag = false;
        }
        $.get(cartAllUrl, { id: id }, function (res) {
            if (res.result == 0) {
                window.location.reload();
            }
        });
    });

    //添加到收藏
    $('.addCollect').click(function () {
        if (confirm('确定加入收藏夹吗？')) {
            var flag = true;
        } else {
            var flag = false;
        }
        var id = $(this).data('id');

        $.get(cartAllUrl, { id: id }, function (res) {
            if (res.result == 0) {
                window.location.reload();
            }
        });
    });


    //修改购物车饰品的数量
    $('.jewelry_quantity').change(function () {
        var allcheck = $(".shoppingcart_table tbody input").length;
        var checkit = $(".shoppingcart_table tbody input[type='checkbox']:checked").length;
        //当复选框全选修改饰品数量时
        if (allcheck == checkit) {
            var _this = $(this);
            var id = $(this).data('id');
            data = { option: $(this).val() };
            $.get(ajaxUpdateNumberUrl, { id: id, data: data }, function (res) {
                if (res.result > 0) {
                    return false;
                }
                var data = res.data;
                _this.parent().parent().parent().find('.pay_money span').html('&yen;' + parseFloat(res.price)); //饰品的总价格
                $("#cart-number strong").text(data.number); //总数量
                _this.parent().parent().parent().find("input[type='checkbox']").val(_this.val()); //改变复选框的值
                _this.parent().parent().parent().find("input[type='checkbox']").attr('data-price', res.price); //把data-price设置为res.price
                _this.parent().parent().parent().find("input[type='checkbox']").attr('checked', true); //选中复选框
                $("#cart-amount strong").html('&yen;' + parseFloat(data.price)); //总价格
            });
            //当复选框没有全部选中时，修改饰品数量时
        } else {
            var _this = $(this);
            var id = $(this).data('id');
            data = { option: $(this).val() };
            $.ajax({
                type: 'GET',
                url: ajaxUpdateNumberUrl,
                data: { id: id, data: data },
                async: false,
                dataType: 'json',
                success: function (res) {
                    if (res.result > 0) {
                        return false;
                    }
                    var data = res.data;
                    _this.parent().parent().parent().find('.pay_money span').html('&yen;' + parseFloat(res.price)); //饰品的总价格
                    // $("#cart-number strong").text(data.number); //总数量
                    _this.parent().parent().parent().find("input[type='checkbox']").val(_this.val()); //改变复选框的值
                    _this.parent().parent().parent().find("input[type='checkbox']").attr('data-price', res.price); //把data-price设置为res.price
                    _this.parent().parent().parent().find("input[type='checkbox']").attr('checked', true); //选中复选框
                    // $("#cart-amount strong").html('&yen;'+parseFloat(data.price)); //总价格
                }
            });

            var number = 0;
            var total_price = 0;
            $('input:checkbox').each(function (index, element) {
                if (element.checked == true) {
                    var num = $(element).val();
                    if (num != '') {
                        number = parseInt($(element).val()) + parseInt(number);
                        // total_price = parseFloat($(element).data('price'))*parseInt(num) + parseFloat(total_price);
                        total_price = parseFloat($(element).attr('data-price')) + parseFloat(total_price);
                    }

                }
            });
            $("#cart-number strong").html(number); //选中的数量
            $("#cart-amount strong").html('&yen;' + total_price); //选择商品的价格
        }


    });

    //购物车的商品移入的收藏夹
    $('.incollect').click(function () {
        var id = $(this).data('id');
        if (confirm('请确认是否将商品移入到收藏夹')) {
            var flag = true;
        } else {
            var flag = false;
        }
        if (flag == true) {
            $.get(incollectUrl.replace(':id', id), function (res) {
                //console.log();
                if (res.result == 0) {
                    window.location.reload();
                } else {
                    return false;
                }
            })
        }
        // return false;
    })

    //将购物车的多个商品移入到收藏夹
    $('.incollet_all').click(function () {
        var data = new Array();

        $('input:checkbox').each(function () {
            if (this.checked == true) {
                var goods_id = $(this).data('good');
                if (typeof (goods_id) != 'undefined') {
                    data.push(goods_id);
                }
            }
        });

        if (confirm('请确认是否将商品移入到收藏夹')) {
            var flag = true;
        } else {
            var flag = false;
        }
        var flag = true;
        if (flag == true) {
            $.get(incollectallUrl, { data: data }, function (res) {
                //console.log(res);
                if (res.result == 0) {
                    window.location.reload();
                } else {
                    return false;
                }
            })
        }
        // return false;
    })

    //购物车立即结算时生成订单
    $('#cart-post').off('click').on('click', function () {
        var choosed = [];
        $('.shoppingcart_table.shoppingcart_tbody').find('.cbox:checked').each(function (index) {
            choosed.push($(this).data('id'));
        });

        if (choosed.length <= 0) {
            alert('请选择商品!');
            // return false;
        }

        $.post(orderCreateUrl, { data: choosed }, function (res) {
            if (typeof (res) != 'object') {
                var errorwaring = new Popping().init({
                    content: "未登录用户",
                    hideTime: 2000
                });

            } else if (res.result == -3 || res.result == -5 || res.result == -8 || res.result == -11) {
                alert(res.message);
                return false;
            } else if (res.result == -4) {
                window.location.href = orderUrl;
            } else if (res.result != 1) {
                return false;
            } else {
                window.location.href = orderUrl;
            }
        });
    });

    //选择付款银行
    $(".pay_way li").off("click").on("click", function () {
        $(".pay_way li div").removeClass("bank_selected");
        $(this).find("div").addClass("bank_selected");
        $(this).find("div").mouseover().css({ "border": "2px solid #c67c59", "background": "#fff url(/bundles/acmefrontend/img/cart/ico-select2.png) right bottom no-repeat" });
        // return false;
    });
    $(".pay_way li").off("mouseenter").on("mouseenter", function () {
        if ($(this).find("div").attr("class") == "bank_selected") {
            $(this).find("div").css({ "border": "2px solid #c67c59", "background": "#fff url(/bundles/acmefrontend/img/cart/ico-select2.png) right bottom no-repeat" });
        }
        // return false;
    }).off("mouseleave").on("mouseleave", function () {
        $(this).find("div").attr("style", "");
        // return false;
    });
    //购物车钻石详情
    $(".ringdetail_show").off('click').on('click', function () {
        $(this).parent().parent().find(".ringdetail_hide").children("div").slideToggle();
        $(this).toggleClass("active");
        // return false;
    });
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
    //添加新地址弹窗
    $(".address_add,.dis-mod").off('click').on('click', function () {
        $('.address_edit').addClass('address_popup');
        $(".address_edit,.dr_blackwall").css("display", "block");
        // $("body,html").onmousewheel
        // return false;
    });
    //隐藏地址弹窗
    $(".address_close").off('click').on('click', function () {
        $(".address_popup input").val("");
        $(".address_popup select").val("");
        $(".address_popup,.dr_blackwall").css("display", "none");
        $("body,html").css("overflow", "auto");
        // return false;
    });
    //删除订单收货地址
    $('a.dis-del').on('click', function () {
        var _this = $(this);
        if (confirm("请确认是否删除?")) {
            _this.parents('.address_list').remove();
        } else {
            return false;
        }
    });


    //获取收件的手机号码
    var address_phone = $('.address_list input:radio:checked').next().find('span').html();
    $('.msg_r label').html(address_phone);
    /*alert(address_phone);*/


    //ajax省市区选择
    var province = $('#province').val();
    var city = $('#city').data('value');
    var distrct = $('#distrct').data('value');
    if (province > 0) {
        $.get(ajaxLoadCity, { id: province }, function (res) {
            $('#city').empty();
            var shtml = '<option value="0">选择城市</option>';
            res = res.data;
            for (var i = 0; i < res.length; i++) {
                shtml += '<option value="' + res[i].id + '"';
                if (city > 0 && res[i].id == city) {
                    shtml += ' selected="selected"';
                }
                shtml += '>' + res[i].name + '</option>';
            }

            $('#city').html(shtml);
        });

        $.get(ajaxLoadCity, { id: city }, function (res) {
            $('#distrct').empty();
            var shtml = '<option value="0">选择地区</option>';
            res = res.data;
            for (var i = 0; i < res.length; i++) {
                shtml += '<option value="' + res[i].id + '"';
                if (distrct > 0 && res[i].id == distrct) {
                    shtml += ' selected="selected"';
                }
                shtml += '>' + res[i].name + '</option>';
            }

            $('#distrct').html(shtml);
        });
    }

    $('#province').off('change').on('change', function () {
        var id = $(this).val();
        $.get(ajaxLoadCity, { id: id }, function (res) {
            $('#city').empty();
            var shtml = '<option value="0">选择城市</option>';
            res = res.data;
            for (var i = 0; i < res.length; i++) {
                shtml += '<option value="' + res[i].id + '">' + res[i].name + '</option>';
            }

            $('#city').html(shtml);
        });
    });

    $('#city').off('change').on('change', function () {
        var id = $(this).val();
        $.get(ajaxLoadCity, { id: id }, function (res) {
            $('#distrct').empty();
            res = res.data;
            var shtml = '<option value="0">选择地区</option>';
            for (var i = 0; i < res.length; i++) {
                shtml += '<option value="' + res[i].id + '">' + res[i].name + '</option>';
            }

            $('#distrct').html(shtml);
        });
    });

    //ajax请求只传地址id而不跳转页面
    $('.address_add').click(function () {
        $.post(orderModify, function () {
            return false;
        });
    });
    $('.dis-mod').on('click', function () {
        var id = $(this).data('id');
        $.post(orderModify, { "id": id }, function (res) {
            /*alert(res.data.cname);*/
            $('#username').val(res.data.username);
            $('#address').val(res.data.address);
            $('#province').val(res.data.province);
            $('#city option').html(res.data.cname);
            $('#distrct option').html(res.data.dname);
            $('#postcode').val(res.data.postcode);
            $('#mobile').val(res.data.mobile);
            $('#data-id').val(res.data.id);
            //市
            /*  $.getJSON(ajaxLoadCity.replace(':id', res.data.province), function(city) {
                  $('#city').empty();
                  city = city.data;
                  var shtml = '<option value="0">选择城市</option>';
                  for (var i = 0; i < city.length; i++) {
                      var selected = '';
                          console.log(city[i].id);
                      if( res.data.city === city[i].id ) {
                          console.log(res.data.city);
                          var selected = 'selected="selected"';
                      }

                      shtml += '<option ' + selected + '  value="' + city[i].id + '">' + city[i].name + '</option>';
                  }
                  $('#city').html(shtml);

                  //区
                  $.getJSON(ajaxLoadCity.replace(':id', res.data.city), function(distrct) {
                      $('#distrct').empty();
                      distrct = distrct.data;
                      var shtml = '<option value="0">选择地区</option>';
                      for (var i = 0; i < distrct.length; i++) {
                          var selected = '';
                          if( res.data.distrct === distrct[i].id ) {
                              var selected = 'selected="selected"';
                          }

                          shtml += '<option  ' + selected + '   value="' + distrct[i].id + '">' + distrct[i].name + '</option>';
                      }

                      $('#distrct').html(shtml);
                  });
              });*/
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

    //提交订单
    $('#order-post').off('click').on('click', function () {
        if ($('.address_list').hasClass('select')) {
            var address = $('.address_list.select #address').data('id');
        }
        if (address == 0) {
            alert('请选择收货地址!');

            return false;
        }
        var receipt = $('.delivery_notic').find('input[type="radio"]:checked').data('type');
        var mobile = $('.msg_r label').html();

        if (receipt == 2) {
            mobile = $('#receipt-phone').val();
            if ($.trim(mobile) == "") {
                alert('请输入电话号码');
                return false;
            }
        }

        var remark = $('#remark').val();

        if ($('.love_agreement_bg').is(':visible')) {
            //确认真爱协议
            if (!$('#agrAccept').is(':checked')) {
                alert('确认真爱协议');
                return false;
            }

            var male = $('#male').val();
            var female = $('#female').val();
            var phone = $('#phone').val();
            //通过遍历纪念日input输入框,进行赋值
            var mdata = new Array();
            var mname = new Array();
            $('.anniversary div').each(function (index) {
                var data = $('.anniversary div').eq(index).find('.anniversary_time').val();
                mdata.push(data);
                var name = $('.anniversary div').eq(index).find('.anniversary_name').val();
                mname.push(name);
                if ((data == '' && name != '') || (data != '' && name == '')) {
                    alert('请完善你们的纪念日信息!');
                    return false;
                }

            });
            if ($.trim(male) == '' || $.trim(female) == '') {
                alert('请填写名字');
                return false;
            }

            var nameFlag = 0;
            $('.agr-memTiem input').each(function (index) {
                if ($(this).attr('name').indexOf('name') > -1 && $(this).val() != '') {
                    nameFlag = 1;
                }
            });
            //暂时拿掉，真爱协议处的短信接受号码非必填项
            if (nameFlag > 0 && ($.trim($('#phone').val()) == '' || !checkMobile($.trim($('#phone').val())))) {
                alert('真爱协议的手机号码填写不正确');
                return false;
            }
        }
        // $('form#memorial').serialize();
        var dataResort = {
            'data[address]': address,
            'data[receipt]': receipt,
            'data[mobile]': mobile,
            'data[remark]': remark,
            'data[male]': male,
            'data[female]': female,
            'data[memorial][phone]': phone,
            'data[memorial][data]': mdata,
            'data[memorial][name]': mname
        };

        $.post(orderCreateUrl, dataResort, function (res) {
            if (res.result == 0) {
                window.location.href = orderPayUrl + '?id=' + res.data.id;
            } else {
                alert(res.message);
            }
        });

        return false;
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

    // //修改送货通知
    // $(".delivery_notic input[type='radio']").off('click').on('click',function(){
    // 	var receipt = $('.delivery_notic').find('input[type="radio"]:checked').data('type');
    // 	if (receipt == 1) {
    // 		var address_phone = $('.address_list input:radio:checked').next().find('span').html();
    // 		$('.msg_r label').html(address_phone);
    // 	}
    // });

    $(".msg_change").off('click').on('click', function () {
        $(".msg_r").css("display", "none");
        $(".msg_o").css("display", "block");
        // return false;
    });
    //如果没有收货人的时候，没有维护其他联系人,直接显示输入框和确认按钮
    $(function () {
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
    });
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
    //添加纪念日
    var add_date = '<div><input type="" name="" id="" value="" placeholder="纪念日日期" readonly="true" class="anniversary_time add_input datatime" /><input type="" name="" id="" value="" placeholder="纪念日名称" class="anniversary_name add_input" /><a href="javascript:;" class="anniversary_remove">删除</a></div>';
    $(".add_anniversary").off('click').on('click', function () {
        $(".anniversary").append(add_date);
        $('.datatime').datetimepicker({
            lang: 'ch',
            timepicker: false,
            format: 'Y-m-d'
        });
        // return false;

    });
   

    // $('.link_btn2').click(function(){
    // 	$('.anniversary div').each(function(index){
    // 		console.log($('.anniversary div').eq(index).find('.anniversary_time').val());
    // 		console.log($('.anniversary div').eq(index).find('.anniversary_name').val());
    // 	});
    // });

    //分批支付填写金额
    $('.morePay').find('input').blur(function () {
        var w = 500;
        var y = 100;
        var pay = parseFloat($('#pay_money').attr('data-price'));
        var morePay = parseFloat($('.morePay').find('input').attr('value'));
        if (isNaN(morePay)) {
            alert('请填写正确的金额');
            return false;
        }

        if (!((pay > w && morePay >= w) || (pay > y && morePay >= y && pay <= w))) {
            if (pay > w) {
                alert('请支付' + w + '以上的金额');
                return false;
            }
            if (pay > y) {
                alert('请支付' + y + '以上的金额');
                return false;
            }

            if (morePay < pay) {
                alert('全额支付');
                return false;
            }
        }

        $('#payMoney').html(morePay.toFixed(3));
    });

    //收银台页面点击立即结算
    $('.link_btn3').off('click').on('click', function () {
        var payment = $('.tab_contents.clearfix').find('.bank_selected').data('type');
        if (!payment) {
            alert('请选择支付方式！');
            return false;
        }
        var payBank = $('.tab_contents.clearfix').find('.bank_selected img').attr('title');
        var price = parseFloat($('.morePay').find('input').attr('value'));
        if (isNaN(price)) {
            price = 0;
        }

        if (price <= 0) {
            price = parseFloat($('#pay_money').attr('data-price'));
        }

        orderPaySubmitUrl = orderPaySubmitUrl + '&payment=' + payment + '&payprice=' + price + '&payBank=' + payBank;

        $.get(orderCheckUrl, function (res) {
            if (res.result == 0) {
                window.location.href = orderPaySubmitUrl;
            } else {
                alert(res.message);
                return false;
            }
        });
    });

    //日期插件
    $(".anniversary_time").off('mouseenter').on('mouseenter', function () {
        $(this).datetimepicker({
            lang: 'ch',
            timepicker: false,
            format: 'Y-m-d'
        });
        $(".xdsoft_year").css("display", "block");
        // return false;
    });
    //生日日期月、日
    $(".databirth").off('mouseenter').on('mouseenter', function () {
        $(this).datetimepicker({
            lang: 'ch',
            timepicker: false,
            format: 'm-d'
        });
        $(".xdsoft_year").css("display", "none");
        // return false;
    });
    //全选,非全选
    $(".check_all").off("click").on("click", function () {
        $(".shoppingcart_table,.shoppingcart_pay").find("input").attr("checked", this.checked);
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
                    // total_price = parseFloat($(this).data('price'))*parseInt(num) + parseFloat(total_price);
                    // total_price = parseFloat($(this).data('price')) + parseFloat(total_price);
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

    fixbottom();
    //立即结算固定

    //点击修改发短信的号码
    $('input[name="addressInfo"]').off('click').on('click', function () {
        var phone = $(this).parent().find('.address_phone').text();
        $('.msg_r label').html(phone);
    })

    $(window).scroll(function () {
        fixbottom();
    }).resize(function () {
        fixbottom();
    });
    // var pay_now = $('.pay_bottom').offset().top;
    
});
function fixbottom() {
        var drcps = $('.dr_footer').offset();
        var window_h = $(window).height();
        var st = $(window).scrollTop() + window_h;
        if (st < drcps + 15) {
            $('.pay_bottom').addClass("pay_float");
        } else {
            $('.pay_bottom').removeClass("pay_float");
        }
    }
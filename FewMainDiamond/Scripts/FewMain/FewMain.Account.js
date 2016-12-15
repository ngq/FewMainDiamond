$(function() {
   
});
// 手机号码验证
jQuery.validator.addMethod("isMobile", function (value, element) {
    var length = value.length;
    var mobile = /^(13[0-9]{9})|(18[0-9]{9})|(14[0-9]{9})|(17[0-9]{9})|(15[0-9]{9})$/;
    return this.optional(element) || (length == 11 && mobile.test(value));
}, "请正确填写您的手机号码");
//自定义提示信息
//账户名
jQuery.validator.addMethod("required", function (value, element) {

    var bool = false;
    if (value !== "") {
        bool = true;
    }
    var dd = bool;
    if (!dd) {
        var msg = $(element).attr("data-alertMsg");
        layer.tips('请输入' + msg, element);
    }
    return dd;
}, "");
/**
 * 登录
 * @returns {} 
 */
function login() {
    $("#login").validate({
        focusInvalid: false,
        onkeyup: false,
        submitHandler:function() {
            $.post("/account/login", $("#login").serialize(), function (data) {
                if (data.IsSuccess) {
                    layer.msg(data.Msg, { time: 1500 });
                } else {
                    layer.msg(data.Msg, { time: 1500 });
                }
            });

        },
        rules: {
            UserName: {
                required: true
            },
            Password: {
                required: true
            }
        }   
    });
}
/**
 * 注册
 * @returns {} 
 */
function register() {
    $("#login").validate({
        focusInvalid: false,
        onkeyup: false,
        submitHandler: function () {
            $.post("/account/register", $("#register").serialize(), function (data) {
                if (data.IsSuccess) {
                    layer.msg(data.Msg, { time: 1500 });
                } else {
                    layer.msg(data.Msg, { time: 1500 });
                }
            });

        },
        rules: {
            UserName: {
                required: true
            },
            Password: {
                required: true
            }
        }
    });
}

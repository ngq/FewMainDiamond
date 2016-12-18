
// 手机号码验证
//jQuery.validator.addMethod("isMobile", function (value, element) {
//    var length = value.length;
//    var mobile = /^(13[0-9]{9})|(18[0-9]{9})|(14[0-9]{9})|(17[0-9]{9})|(15[0-9]{9})$/;
//    return this.optional(element) || (length == 11 && mobile.test(value));
//}, "请正确填写您的手机号码");
//自定义提示信息

/**
 * 登录
 * @returns {} 
 */
function login() {
    $("#login").validate({
        focusInvalid: false,
        onkeyup: false,
        submitHandler: function () {
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
    $("#register").validate({
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

        }, rules: {
            UserName: {
                required: true,
                Password: true
            },
            Password: {
                required: true,
                email: true
            }
        },
        messages: {
            CurrentPwd: {
                required: "旧密码必须填写"
            },
            Email: {
                required: "请填写邮箱",
                email: "请输入正确的email地址"
            }
        }
    });
}

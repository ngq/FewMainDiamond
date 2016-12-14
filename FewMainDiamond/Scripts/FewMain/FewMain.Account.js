$(function() {

});
/**
 * 登录
 * @returns {} 
 */
function login() {
    $("#login").validate({
        focusInvalid: false,
        onkeyup: false,
        submitHandler:function() {
            $.post("", {}, function(data) {
                if (data.IsSuccess) {
                    layer.msg(data.Msg, { time: 1500 });
                } else {
                    layer.msg(data.Msg, { time: 1500 });
                }
            });

        }
    });
}
function register() {
    
}

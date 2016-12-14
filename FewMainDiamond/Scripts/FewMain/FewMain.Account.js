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
                    
                }
            });

        }
    });
}
function register() {
    
}

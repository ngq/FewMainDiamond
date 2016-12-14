$(function () {
    //如果是移动端的话就跳转到移动端页面
    var urlMobile = '移动端链接';
    if (isMobile() !== false) window.location.href = urlMobile;
    //在导航鼠标经过时,添加背景图片颜色以及找到下方的span标签并设置其背景颜色 以及显示出来,鼠标移出则相反
    $("ul.topnav li").hover(function () {
        $(this).css({ 'background': 'url(Content/images/base/bg1.jpg) repeat-x 0px 53px' });
        $(this).find("span").show(); //显示span标签内容
        $(this).find("span").css({ 'background': '#FFF' });
    }, function () {
        $(this).css({ 'background': 'none' });
        $(this).find("span").hide();
    });
    //左侧客服部分鼠标移动上去后显示隐藏
    $(".chat_f1_expr .list").find("b").hover(function () {
        $(this).next().show();
    }, function () { $(this).next().hide(); });
    //--- 开始--- app下载 微信扫码 点击显示隐藏
    $('.theme-login').click(function () {
        $('.theme-popover-mask').fadeIn(100);
        $('.theme-popover').slideDown(200);
    })
    $('.theme-poptit .close').click(function () {
        $('.theme-popover-mask').fadeOut(100);
        $('.theme-popover').slideUp(200);
    })

    $('.theme-login2').click(function () {
        $('.theme-popover-mask').fadeIn(100);
        $('.theme-popover2').slideDown(200);
    })
    $('.theme-poptit2 .close').click(function () {
        $('.theme-popover-mask').fadeOut(100);
        $('.theme-popover2').slideUp(200);
    })
    //--- 结束--- app下载 微信扫码 点击显示隐藏

    //购物车全选
    $('#cartchkall').click(function () {
        alert($('#cartchkall').is(':checked'));
        if ($('#cartchkall').is(':checked')) {
            alert(1);
            $(".checkbox").each(function () {
                
                $(this).attr('checked', 'checked');
            })
        } else {

            $(".checkbox").attr('checked', false);
        }
    });
});

//##################函数开始#########################
//款式页分类选择
function setTab(name, cursel, n) {
    for (i = 1; i <= n; i++) {
        var menu = document.getElementById(name + i);
        var con = document.getElementById("con_" + name + "_" + i);
        menu.className = i == cursel ? "hover" : "";
        con.style.display = i == cursel ? "block" : "none";
    }
}
//判断是否是移动端
function isMobile() {
    if ((navigator.userAgent.match(/(phone|pad|pod|iPhone|iPod|ios|iPad|Android|Mobile|BlackBerry|IEMobile|MQQBrowser|JUC|Fennec|wOSBrowser|BrowserNG|WebOS|Symbian|Windows Phone)/i)))
        return true;
    else
        return false;
}


//钻石选购列表页背景选择
function bgChange() {
    var lis = document.getElementsByTagName('dl');

    for (var i = 2; i < lis.length; i += 2)
        lis[i].style.background = '#f7f7f7';
}

//##################函数结束#########################
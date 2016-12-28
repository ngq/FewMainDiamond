/*
 * 底部入口模块
 * 2015-06-27 14:00
 * */
define(function(require,exports,module){
	/*通过 require 引入依赖*/
	require('jquery');
	var drToggle = require('js/modules/drtoggle.js');  
	$(function(){
		
		/*回到顶部*/
		$('.dr_totop').off('click').on('click',function(){
			$("html,body").stop(true, false).animate({ "scrollTop": 0 + 'px' }, 300)
		});
		
		/*显示隐藏侧边栏工具*/
		var scrollTop = '';
		var offon = true;
		checkScroll();
		$(window).bind('scroll',function(){			
		    checkScroll();
		});		
		function checkScroll() {
		    scrollTop = $(document).scrollTop();
		    if (scrollTop >= 200 & offon) {
		    	offon = false;
		        $('#dr-quickservice').show();
		        $('.droline_kfword').animate({left:'-230px',opacity:1},500).show();
		        $('.droline_kfword p').animate({ width: '220px', height: '48px' }, 1000);


		        var display = getCookie("is_display");

		        var url = window.location.href;
		        url = url.split('/');
		        var timestamp = parseInt(new Date().getTime() / 1000);//当前时间戳

		        if(url.length <= 4 && display == null && '1484928000' > timestamp ) {
		        	if('1482681600' > timestamp ){
		        		$('.dr_Reminder p').html('亲爱的DR族，在圣诞<br />繁忙期间，为了确保您<br />定制的Darry Ring可以<br />及时送达，建议您提<br />前选购商品哦。详情请<br />咨询客服。');
		        	}	

		        	$('.dr_Reminder').animate({left:'-216px',opacity:1},500).show();
				 	setCookie('is_display', 1);
		        } else {
		        	$(".dr_Reminder").hide();
		        }
		        setTimeout(hidetcword,6000);
		    } else if (scrollTop <= 200) {
		        $('#dr-quickservice').hide();
		    } else {
		        $('#dr-quickservice').show();
		    }
		};
		//侧边工具栏提示效果
		$('.dr_quick-cort').off('mouseenter').on('mouseenter',function(){
			$(this).addClass('dr_quickcort-hover').find('.dr_quick-word').stop(false,false).animate({right:'50px',opacity:1},500).show();
		}).off('mouseleave').on('mouseleave',function(){			
			$(this).removeClass('dr_quickcort-hover').find('.dr_quick-word').stop(false,false).animate({right:'0',opacity:0},500).hide();
		});
		//底部帮助中心分享
		var draboutUs = new drToggle().init({
			id:'#dr_help-gz',
			action:'.dr_help-all .comShare'
		});	
		//点击关闭客服文字
		$('.droline_kfword span').click(function(){
			hidetcword();
			offon = false;
			return false;
		});
		//点击关闭温馨提示
		$('.dr_Reminder span').click(function(){
			$('.dr_Reminder').animate({left:'0',opacity:0},500);
			return false;
		});
		
		//点击出现客服弹窗(2016.8.8)
		$('.droline_showkf').click(function(){
			$('.dr_blackwall,.drKf_tc').show();
		});
		//点击客服弹窗消失
		$('.drKf_close').click(function(){
			$('.dr_blackwall,.drKf_tc').hide();
		});
		showtcword();
		//底部后台程序js代码处
		
	});
});

/*随机显示文字*/
function showtcword(){
	var wordlen = 6;
	var wordNum = Math.floor(Math.random()*wordlen);
	var wordshow = new Array(wordlen);
	wordshow[0]="想了解更多钻石知识<br/>我们有专业在线客服给您解答";
	wordshow[1]="定制合适的戒指手寸<br/>可以联系客服协助您进行估算";
	wordshow[2]="挑选满意的戒指款式<br/>在线客服可以给您提供建议";
	wordshow[3]="购买过程遇到问题<br/>直接联系在线客服解决";
	wordshow[4]="想了解钻戒定制流程<br/>在线客服可以给您介绍说明";
	wordshow[5]="欢迎光临Darry Ring<br/>有问题客服都可以帮您解答";
	$('.droline_kfword p').html(wordshow[wordNum]);	
}
/*关闭客服文字弹窗*/
function hidetcword(){
	$('.droline_kfword').animate({left:'0',opacity:0},500);
}


function setCookie(c_name,value,expiredays)
{
	var exdate=new Date();
	exdate.setDate(exdate.getDate()+expiredays);
	document.cookie=c_name+ "=" + escape(value)+((expiredays==null) ? "" : ";expires="+exdate.toGMTString());
}

function getCookie(name)
{
	var arr,reg=new RegExp("(^| )"+name+"=([^;]*)(;|$)");
	if(arr=document.cookie.match(reg)){
		return unescape(arr[2]);
	} else {
		return null;
	}
}

/*
 * 头部入口模块
 * 2015-06-27 14:00
 * */
define(function(require,exports,module){
	/*通过 require 引入依赖*/
	require('jquery');	
	var drToggle = require('js/modules/drtoggle.js');
	var Tabs = require('js/modules/tabs.js');
	var Banner_nav = require('js/modules/banner.js');
	var twoTabs = require('js/modules/twoTabs.js');
	
	var Popping = require('js/modules/popping.js');

	$(function(){
		//语言切换显示隐藏
		var drlangues = new drToggle().init({
			id:'#dr-country',
			action:'#dr-english'
		});	
		//首页子菜单显示隐藏
		var drindex = new drToggle().init({
			id:'#DrNav',
			action:'#DRsubNav'
		});
		//求婚钻戒子菜单显示隐藏
		var drqhzj = new drToggle().init({
			id:'#qhzjNav',
			action:'#qhzjsubNav'
		});	
		//真爱时刻子菜单显示隐藏
		var drzasks = new drToggle().init({
			id:'#zaskNav',
			action:'#zasksubNav'
		});	
		//实体店子菜单显示隐藏
		var drzasks = new drToggle().init({
			id:'#shopNav',
			action:'#ShopsubNav'
		});	
		//品牌文化子菜单显示隐藏
		var drzasks = new drToggle().init({
			id:'#ppwhNav',
			action:'#ppwhsubNav'
		});	
		//DR社区子菜单显示隐藏
		var drzasks = new drToggle().init({
			id:'#DRsqNav',
			action:'#DRsqsubNav'
		});	
		//登陆之后操作项显示隐藏
		var drlogin = new drToggle().init({
			id:'#loginInInfo',
			action:'#loginInaAtion'
		});	
		//导航栏实体店轮播
		var nav_slider = new Banner_nav().init({
		 	id:'#drnav_slider',
		 	time: 2500
		});	 
		//头部菜单店铺切换效果
		var shopTabsNav = new twoTabs().init({
			id:'#drstore-tab-nav',
			firstWidth:26,
			otherWidth:58,
			timer: 300
		});
		//所在城市店铺
		$('.dr_member-ip').off('mouseenter').on('mouseenter',function(){
			$(this).addClass('dr_member-iphover');
		}).off('mouseleave').on('mouseleave',function(){
			$(this).removeClass('dr_member-iphover');
		});
		$('.dr_member-ipxl a').off('click').on('click',function(){
			$('.dr_member-ipxl a').removeClass('dr_member-ipxlclick');
			$(this).addClass('dr_member-ipxlclick');
			$('.dr_member-ipspecial').html($(this).html());
		});
		//真爱验证提示
		 var drloveVerify = new drToggle().init({
			id:'.drmember_yz',
			action:'.drmember_yz-word'
		});	
		$('.drmember_yz').hover(function(){
			$(this).css('z-index',7);
		},function(){
			$(this).css('z-index',0);
		});
		$('.drmember_yzborderul span').click(function(){
			$('.drmember_yzborderul ul').show();
			$('.drmember_yzborderul').addClass('drmember_yzborderclick');
			$(this).hide();
			return false;
		});
		$('body').click(function(){
			$('.drmember_yzborderul ul').hide();
			$('.drmember_yzborderul span').show();
			$('.drmember_yzborderul').removeClass('drmember_yzborderclick');
		});
		$('.drmember_yzborderul ul li').click(function(){

			$('.drmember_yzborderul').find('span').html($(this).html());
			$('.drmember_yzborderul ul').hide();
			$(".tohide").val($(this).html());
			$('.drmember_yzborderul span').show();
			$(this).addClass('xz');
			$('.drmember_yzborderul').removeClass('drmember_yzborderclick');
		});	
		/*点击简繁切换*/
		$('.drmember_dl1').click(function(){
			$('#txtIDCardw').attr('placeholder','请输入身份证号验证真爱承诺');
		});
		$('.drmember_dl2').click(function(){
			$('#txtIDCardw').attr('placeholder','請輸入護照編號驗證真愛承諾');
		});
		$('.drmember_dl3').click(function(){
			$('#txtIDCardw').attr('placeholder','請輸入港澳台身份證號碼驗證');
		});
		$('.drmember_dl4').click(function(){
			$('#txtIDCardw').attr('placeholder','请输入国家证件号码验证真爱承诺');
		});
		//验证为空时
		if($('#txtIDCardw').val() == ''){
			$('.drmember_yz-word').removeClass('drmember_yz-wrong');
		}
		//导航产品图片轮换
		$('.dr_navTabs').each(function(){
			new Tabs().init({
				tabsTops: $(this).find('.dr_navsuvleft-same a'),
				tabsMains: $(this).find('.dr_navsuvleft-ring a'),
				event: 'mouseenter'
			});
			new Tabs().init({
				tabsTops: $(this).find('.dr_navsuvright-same a'),
				tabsMains: $(this).find('.dr_navsuvright-ring a'),
				event: 'mouseenter'
			});
		});
		//点击去掉文字输入提示
        $('#txtIDCardw').focus(function () {
            $(this).attr('placeholder', '');
            $('.drmember_yz-word').hide();
        }).blur(function () {
            if ($('.tohide').val() == '海外地区') {
                $(this).attr('placeholder', '請輸入護照編號驗證真愛承諾');
            }
            else if($('.tohide').val() == '港澳台'){
            	$(this).attr('placeholder', '請輸入港澳台身份證號碼驗證');
            }
            else if($('.tohide').val() == '其他'){
            	$(this).attr('placeholder', '请输入国家证件号码验证真爱承诺');
            }
            else {
                $(this).attr('placeholder', '请输入身份证号验证真爱承诺');
            }
        });
		//头部新增APP下载通道
        $('.drapp_dowonload').hover(function(){
        	$(this).addClass('drapphide_show');
        },function(){
        	$(this).removeClass('drapphide_show');
        });

		//头部后台程序js代码处
		$('.drmember_yz').hover(function(){
			setTimeout(Tsnews,5000);
		});




		//头部输入框真爱查询
        	$("#btnnSeach,.queryBtn").click(function(){ 
	        	$("#dr_sfwrong").removeClass("index_yz-word").addClass("drmember_yz-wrong")
	
					var identity = $('#card').val();
					var type = $('.xz').attr('data-type');
					if(typeof(type) === 'undefined') {
						var type = 1;
					}
		            
					if (type == 3) {
						 _identity = identity;
						 identity = identity.replace('(', '').replace(')', '');
						 console.log(HKIdValid(identity));
					
						if (identity.length == 8) {
							flag = HKIdValid(identity);
							if (flag == false) {
								flag = MCIdValid(identity);
							}
						} else {
							flag = TWIdValid(identity);
						}

						if (flag == false && _identity.length == 10 ) {
                            flag = true;
						}

						if (flag == false) {
							$("#dr_sfwrong").html("<p>護照編號輸入有誤，請重新輸入。</p>");
							return false;
						}
					} else if(true != IdentityValid(identity) && type == 1) {
		            	$("#dr_sfwrong").html("<p>身份证有误，请重新输入。</p>");
		            	return false;
		            } else if (type == 2 && true != PPIdValid(identity)) {
						$("#dr_sfwrong").html("<p>您的身份證號碼輸入有誤，請重新輸入。</p>");
						return false;
					} 
					
                    $("#aspnetForm").submit();
				// 	$.get(checkUrl, {type: type, identity: identity}, function(res) {
				// 		/*alert(res.result);
				// 		return false;*/
				// 		if(res.result == -1) {
				// 			alert(res.message);
				// 			return false;
				// 		} else {
				// 			window.location.href = res.message;
				// 		}
		                 
				// });
               
           
         });
		//国家地区选择,切换input提示信息
		$('.love_country').each(function(index){
				$('.love_country i').click(function(){
					$(this).addClass('country_click').siblings().removeClass('country_click');
				});
				$('.love_country i').eq(0).click(function(){
					$('.love_theIDnum input').attr('placeholder','请输入身份证号验证真爱承诺');
				});
				$('.love_country i').eq(1).click(function(){
					$('.love_theIDnum input').attr('placeholder','請輸入護照編號驗證真愛承諾');
				});
				$('.love_country i').eq(2).click(function(){
					$('.love_theIDnum input').attr('placeholder','請輸入港澳台身份證號碼驗證');
				});
				$('.love_country i').eq(3).click(function(){
					$('.love_theIDnum input').attr('placeholder','请输入国家证件号码验证真爱承诺');
				});
		});

		//点击关闭弹窗
		$('.Popup_close,.goto_shop').off('click').on('click',function(){
			$('.dr_sametc,.dr_blackwall, .Verifica_nobuy').hide();
			clearInterval(window.loginInterval);
			window.clearInterval(window.toUrl);
		});
	});
});
//提示消失
function Tsnews(){
	$('.drmember_yz-word').hide();
}

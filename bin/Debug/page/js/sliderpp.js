/*图片横向滚动*/
$(function(){
	$('.srcoll_04 div').scrollable({size:4,loop:true,items:'.srcoll_03 div ul'}).autoscroll();
	
});


$(function(){
	$('.srcoll_04 div ul li a img').click(
		 function(){
		 $('.show_box img').attr('src',''+$(this).attr('src')+'');
			//alert($(this).attr('rel'))
		 $('.show_box').find('a').attr('href',''+$(this).attr('src')+'');
	 })	   
})


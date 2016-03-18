
$(function(){
$(".dh").eq(dhid).find("a:eq(0)").addClass("Now");
if ($.browser.msie && ($.browser.version == "6.0") && !$.support.style) { 
} else{
$(".dh").eq(dhid).find("ul").show();
$(".dh").eq(dhid).find("ul li").show();

}


$(".dh").hover(function(){
$(".dh").find("ul").hide();$(".dh").find("ul li").hide();
$(this).find("ul").show();
$(this).find("ul li").animate({opacity: 'show'},400);
},function(){})
})

function set_focus_imgs()
{
 
var total_flag = 'focus_total_logout_';		//统计标识，登录前

ljf('flash_id1').innerHTML = '';ljf('flash_id1_1').innerHTML = '';var rvt = new RevealTrans('flash_id1', {Auto:true, Transition:23}, { flash_id1_1:6 });for(var i = 0; i < datas.length; i++){if(rvt.List.length >= 10) break;
 
 
if(!datas[i].loc.length)
rvt.Add(datas[i].img, datas[i].url, datas[i].title, total_flag + (i+1));
else
for(var j = 0; j < datas[i].loc.length; j++){
if(datas[i].loc[j]){
rvt.Add(datas[i].img, datas[i].url, datas[i].title, total_flag + (i+1));
break;
}
}
}
rvt.Start();
}


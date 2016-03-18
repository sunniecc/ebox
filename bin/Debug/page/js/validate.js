
function al( str ){
	
	var re = [];
	re = stringToBytes(str);
	var sum = 0;
	for(var i = 0 ; i < re.length;i++){
		var l = new Number(re[i]);
		if(i == 0){
			var t = re[i].toString(16);
			var a = "0x"+t+"0000000000";
			var l = new Number(a);
			re[i] = new Number(l.toString(10));
		}else if(i==1){
			var t = re[i].toString(16);
			var a = "0x"+t+"00000000";
			var l = new Number(a);
			re[i] = new Number(l.toString(10));
		}else if(i==2){
			re[i] = (l & 0xff) << 24;
		}else if(i==3){
			re[i] = (l & 0xff) << 16;
		}else if(i==4){
			re[i] = (l & 0xff) << 8;
		}else if(i==5){
			re[i] = (l & 0xff) << 0;
		}
		sum = sum+re[i];
	}

	return sum;
}

function stringToBytes ( str ) {  
  var ch, st, re = [];  
  for (var i = 0; i < str.length; i++ ) {  
    ch = str.charCodeAt(i);  // get char   
    st = [];                 // set up "stack"  
    do {  
      st.push( ch & 0xFF );  // push byte to stack  
      ch = ch >> 8;          // shift value down by 1 byte  
    }    
    while ( ch );  
    re = re.concat( st.reverse() );  
  }  
  return re;  
}  
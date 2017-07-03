function func(skey){
	var hash=5381;
	for(var i=0,len=skey.length;i<len;++i)
		hash+=(hash<<5)+skey.charAt(i).charCodeAt();//hash+=(hash<<5)+skey.charCodeAt(i);
	return hash&2147483647
}

/*

function getACSRFToken(){
	return arguments.callee._DJB(getACSRFToken._getS("skey"))
}
getACSRFToken._DJB=function(str){
	var hash=5381;
	for(var i=0,len=str.length;i<len;++i)
		hash+=(hash<<5)+str.charAt(i).charCodeAt();
	return hash&2147483647
};
getACSRFToken._getS=function(name){
	var r=new RegExp("(?:^|;+|\\s+)"+name+"=([^;]*)"),
	m=document.cookie.match(r);
	return!m?"":m[1]
};
*/
/*
QZONE.FrontPage.getACSRFToken=function(){
	var skey=QZFL.cookie.get("p_skey")||QZFL.cookie.get("skey")||QZFL.cookie.get("rv2");
	return arguments.callee._DJB(skey)
};
QZONE.FrontPage.getACSRFToken._DJB=function(str){
	var hash=5381;
	for(var i=0,len=str.length;i<len;++i)
		hash+=(hash<<5)+str.charAt(i).charCodeAt();
	return hash&2147483647
};
*/

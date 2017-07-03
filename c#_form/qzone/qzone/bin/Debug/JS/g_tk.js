/*
QZFL.pluginsDefine.getACSRFToken=function(){
	var skey=QZFL.cookie.get("p_skey")||QZFL.cookie.get("skey")||QZFL.cookie.get("rv2");
	return arguments.callee._DJB(skey)
};

QZFL.pluginsDefine.getACSRFToken._DJB=function(str){
	var hash=5381;
	for(var i=0,len=str.length;i<len;++i)
		hash+=(hash<<5)+str.charCodeAt(i);
	return hash&2147483647
};
*/
getG_TK=function(skey){
	var hash=5381;
	for(var i=0,len=skey.length;i<len;++i)
		hash+=(hash<<5)+skey.charCodeAt(i);
	return hash&2147483647
}
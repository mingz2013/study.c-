function func(a){
	var f = (Math.round(Math.random() * 2147483647) * (new Date().getUTCMilliseconds())) % 10000000000;
	var pgv_info= "ssid=s" + f;
	return pgv_info
	//return "123"
}

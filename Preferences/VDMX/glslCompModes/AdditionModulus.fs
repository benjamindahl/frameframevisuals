vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec4		DB = vec4(bottom.a)*bottom;
	DB.a = bottom.a;
	float		TA = top.a*topAlpha;
	vec4		DT = vec4(TA) * top;
	DT.a = TA;
	vec4		returnMe = DT+DB;
	returnMe.r = (returnMe.r > 1.0) ? (returnMe.r - 1.0) : returnMe.r;
	returnMe.g = (returnMe.g > 1.0) ? (returnMe.g - 1.0) : returnMe.g;
	returnMe.b = (returnMe.b > 1.0) ? (returnMe.b - 1.0) : returnMe.b;
	//returnMe.a = (returnMe.a > 1.0) ? (returnMe.a - 1.0) : returnMe.a;
	returnMe.a = 1.0;
	return returnMe;
	
	/*
	vec4		returnMe = (vec4(bottomAlpha)*bottom) + (vec4(topAlpha)*top);
	returnMe.r = (returnMe.r > 1.0) ? (returnMe.r - 1.0) : returnMe.r;
	returnMe.g = (returnMe.g > 1.0) ? (returnMe.g - 1.0) : returnMe.g;
	returnMe.b = (returnMe.b > 1.0) ? (returnMe.b - 1.0) : returnMe.b;
	//returnMe.a = (returnMe.a > 1.0) ? (returnMe.a - 1.0) : returnMe.a;
	returnMe.a = 1.0;
	return returnMe;
	*/
}


vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	return vec4(bottom.r, bottom.g, bottom.b, bottom.a*bottomAlpha);
}
vec4 CompositeTop(vec4 top, float topAlpha)	{
	vec4		returnMe = vec4(topAlpha)*top;
	returnMe.a = 1.0;
	return returnMe;
}

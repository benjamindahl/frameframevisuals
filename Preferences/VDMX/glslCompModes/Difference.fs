vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec4		DB = vec4(bottom.a)*bottom;
	DB.a = bottom.a;
	float		TA = top.a*topAlpha;
	vec4		DT = vec4(TA) * top;
	DT.a = TA;
	vec4		returnMe = abs(DT-DB);
	returnMe.a = 1.0;
	return returnMe;
	
	
	/*
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = abs((vec4(topAlpha)*top)-darkenedBottom);
	returnMe.a = top.a;
	returnMe = mix(darkenedBottom, returnMe, topAlpha*top.a);
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

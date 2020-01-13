vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe;
	
	returnMe.r = (darkenedBottom.r == 1.0)
		? darkenedBottom.r
		: min((top.r * top.r / (1.0 - darkenedBottom.r)), 1.0);
	returnMe.g = (darkenedBottom.g == 1.0)
		? darkenedBottom.g
		: min((top.g * top.g / (1.0 - darkenedBottom.g)), 1.0);
	returnMe.b = (darkenedBottom.b == 1.0)
		? darkenedBottom.b
		: min((top.b * top.b / (1.0 - darkenedBottom.b)), 1.0);
	
	//returnMe.a = (darkenedBottom.a == 1.0)
	//	? darkenedBottom.a
	//	: min((top.a * top.a / (1.0 - darkenedBottom.a)), 1.0);
	returnMe.a = top.a;
	
	returnMe = mix(darkenedBottom, returnMe, topAlpha*top.a);
	return returnMe;
	
}


vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	vec4		returnMe = vec4(bottomAlpha)*bottom;
	returnMe.a = 1.0;
	return returnMe;
}
vec4 CompositeTop(vec4 top, float topAlpha)	{
	vec4		returnMe = vec4(topAlpha)*top;
	returnMe.a = 1.0;
	return returnMe;
}

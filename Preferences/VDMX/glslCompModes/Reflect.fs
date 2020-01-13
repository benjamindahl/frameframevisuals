vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe;
	
	returnMe.r = (top.r == 1.0)
		? top.r
		: min((darkenedBottom.r * darkenedBottom.r / (1.0 - top.r)), 1.0);
	returnMe.g = (top.g == 1.0)
		? top.g
		: min((darkenedBottom.g * darkenedBottom.g / (1.0 - top.g)), 1.0);
	returnMe.b = (top.b == 1.0)
		? top.b
		: min((darkenedBottom.b * darkenedBottom.b / (1.0 - top.b)), 1.0);
	
	//returnMe.a = (top.a == 1.0)
	//	? top.a
	//	: min((darkenedBottom.a * darkenedBottom.a / (1.0 - top.a)), 1.0);
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

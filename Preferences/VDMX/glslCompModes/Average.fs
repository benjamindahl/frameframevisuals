vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = (darkenedBottom + top)/vec4(2.0);
	returnMe.a = top.a;
	returnMe = mix(darkenedBottom, returnMe, top.a*topAlpha);
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

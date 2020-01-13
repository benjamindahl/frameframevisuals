vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = darkenedBottom * top;
	returnMe.a = top.a;
	returnMe = mix(darkenedBottom, returnMe, topAlpha*top.a);
	return returnMe;
	
	
	
	
	/*
	R = Base × Blend
	*/
}


vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}
vec4 CompositeTop(vec4 top, float topAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}

vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = vec4(1.0) - ((vec4(1.0)-darkenedBottom) * (vec4(1.0)-top));
	returnMe.a = top.a;
	returnMe = mix(darkenedBottom, returnMe, top.a*topAlpha);
	return returnMe;
	
	/*
	R = 1 - (1-Base) × (1-Blend)
	*/
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

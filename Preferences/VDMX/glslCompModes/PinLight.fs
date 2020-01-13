vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe;
	
	returnMe.r = (top.r > 0.5)
		? max(darkenedBottom.r, (2.0 * (top.r - 0.5)))
		: min(darkenedBottom.r, (2.0 * top.r));
	returnMe.g = (top.g > 0.5)
		? max(darkenedBottom.g, (2.0 * (top.g - 0.5)))
		: min(darkenedBottom.g, (2.0 * top.g));
	returnMe.b = (top.b > 0.5)
		? max(darkenedBottom.b, (2.0 * (top.b - 0.5)))
		: min(darkenedBottom.b, (2.0 * top.b));
	
	returnMe.a = (top.a > 0.5)
		? max(darkenedBottom.a, (2.0 * (top.a - 0.5)))
		: min(darkenedBottom.a, (2.0 * top.a));
	
	
	//returnMe.a = top.a;
	returnMe = mix(darkenedBottom, returnMe, topAlpha*top.a);
	return returnMe;
	
	/*
	if (Blend > ½) R = max(Base,2×(Blend-½))
	if (Blend <= ½) R = min(Base,2×Blend))
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

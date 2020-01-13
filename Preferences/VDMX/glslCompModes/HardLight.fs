vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe;
	
	returnMe.r = (top.r > 0.5)
		? (1.0 - (1.0 - darkenedBottom.r) * (1.0 - 2.0 * (top.r - 0.5)))
		: (darkenedBottom.r * (2.0 * top.r));
	returnMe.g = (top.g > 0.5)
		? (1.0 - (1.0 - darkenedBottom.g) * (1.0 - 2.0 * (top.g - 0.5)))
		: (darkenedBottom.g * (2.0 * top.g));
	returnMe.b = (top.b > 0.5)
		? (1.0 - (1.0 - darkenedBottom.b) * (1.0 - 2.0 * (top.b - 0.5)))
		: (darkenedBottom.b * (2.0 * top.b));
	
	returnMe.a = top.a;
	returnMe = mix(darkenedBottom, returnMe, topAlpha*top.a);
	return returnMe;
	
	/*
	if (Blend > ½) R = 1 - (1-Base) × (1-2×(Blend-½)) 
	if (Blend <= ½) R = Base × (2×Blend) 
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

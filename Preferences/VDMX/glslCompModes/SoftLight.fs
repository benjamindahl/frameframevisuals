vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe;
	
	returnMe.r = (top.r > 0.5)
		? (1.0 - (1.0 - darkenedBottom.r) * (1.0 - (top.r - 0.5)))
		: (darkenedBottom.r * (top.r + 0.5));
	returnMe.g = (top.g > 0.5)
		? (1.0 - (1.0 - darkenedBottom.g) * (1.0 - (top.g - 0.5)))
		: (darkenedBottom.g * (top.g + 0.5));
	returnMe.b = (top.b > 0.5)
		? (1.0 - (1.0 - darkenedBottom.b) * (1.0 - (top.b - 0.5)))
		: (darkenedBottom.b * (top.b + 0.5));
	
	returnMe.a = (top.a > 0.5)
		? (1.0 - (1.0 - darkenedBottom.a) * (1.0 - (top.a - 0.5)))
		: (darkenedBottom.a * (top.a + 0.5));
	
	//returnMe.a = top.a * topAlpha;
	returnMe = mix(darkenedBottom, returnMe, topAlpha*top.a);
	return returnMe;
	
	/*
	if (Blend > ½) R = 1 - (1-Base) × (1-(Blend-½)) 
	if (Blend <= ½) R = Base × (Blend+½) 
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

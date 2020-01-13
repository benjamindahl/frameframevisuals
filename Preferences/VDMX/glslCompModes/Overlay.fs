vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe;
	
	returnMe.r = (darkenedBottom.r > 0.5)
		? (1.0 - (1.0 - (2.0 * (darkenedBottom.r - 0.5))) * (1.0 - top.r))
		: ((2.0 * darkenedBottom.r) * top.r);
	returnMe.g = (darkenedBottom.g > 0.5)
		? (1.0 - (1.0 - (2.0 * (darkenedBottom.g - 0.5))) * (1.0 - top.g))
		: ((2.0 * darkenedBottom.g) * top.g);
	returnMe.b = (darkenedBottom.b > 0.5)
		? (1.0 - (1.0 - (2.0 * (darkenedBottom.b - 0.5))) * (1.0 - top.b))
		: ((2.0 * darkenedBottom.b) * top.b);
	
	returnMe.a = (darkenedBottom.a > 0.5)
		? (1.0 - (1.0 - (2.0 * (darkenedBottom.a - 0.5))) * (1.0 - top.a))
		: ((2.0 * darkenedBottom.a) * top.a);
	
	
	//returnMe.a = top.a;
	returnMe = mix(darkenedBottom, returnMe, topAlpha*top.a);
	return returnMe;
	
	/*
	if (Base > ½) R = 1 - (1-2×(Base-½)) × (1-Blend) 
	if (Base <= ½) R = (2×Base) × Blend
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

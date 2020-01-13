vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{	
	//	This code behavior designed to match the CoreImage minimum mode
	vec4		returnMe;
	returnMe.r = (top.r * topAlpha < bottom.r * bottomAlpha) ? (top.r * topAlpha) : (bottom.r * bottomAlpha);
	returnMe.g = (top.g * topAlpha < bottom.g * bottomAlpha) ? (top.g * topAlpha) : (bottom.g * bottomAlpha);
	returnMe.b = (top.b * topAlpha < bottom.b * bottomAlpha) ? (top.b * topAlpha) : (bottom.b * bottomAlpha);
	returnMe.a = (top.a * topAlpha < bottom.a * bottomAlpha) ? (top.a * topAlpha) : (bottom.a * bottomAlpha);
		
	//	This code does maximum brightness by overall pixel
	//	Might be useful as its own shader
	//float		brightBot = bottomAlpha * bottom.a * (bottom.r + bottom.g + bottom.b) / 3.0;
	//float		brightTop = topAlpha * top.a * (top.r + top.g + top.b) / 3.0;
	//vec4		returnMe;
	//returnMe = (brightBot < brightTop) ? (bottom * bottomAlpha) : (top * topAlpha);
	
	return returnMe;
}


vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	vec4		returnMe = vec4(bottomAlpha)*bottom;
	//returnMe.a = 1.0;
	return returnMe;
}
vec4 CompositeTop(vec4 top, float topAlpha)	{
	vec4		returnMe = vec4(topAlpha)*top;
	//returnMe.a = 1.0;
	return returnMe;
}

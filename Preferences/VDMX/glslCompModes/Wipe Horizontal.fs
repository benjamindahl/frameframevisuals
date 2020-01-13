

vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec2		loc = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = darkenedBottom;
	returnMe = (topAlpha < loc.x) ? returnMe : top;
	return returnMe;
}


vec4 CompositeBottom(vec4 bottom, float bottomAlpha)    {
    vec2        loc = gl_FragCoord.xy / _VVCanvasRect.zw;
    vec4        returnMe = (bottomAlpha < loc.x) ? vec4(0.) : bottom;
    return returnMe;
}

vec4 CompositeTop(vec4 top, float topAlpha)	{
	vec2		loc = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		returnMe = vec4(0.0);
	returnMe = (topAlpha < loc.x) ? returnMe : top;
	return returnMe;
}

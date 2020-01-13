//	adapted from http://transitions.glsl.io/transition/d71472a550601b96d69d

const vec2 heartSize = vec2(0.5,0.4);

bool inHeart (vec2 p, vec2 center, float size) {
	if (size == 0.0) return false;
	vec2 o = (p-center)/(1.6*size);
	return pow(o.x*o.x+o.y*o.y-0.3, 3.0) < o.x*o.x*pow(o.y, 3.0);
}
 
vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)	{
	float		side = max(_VVCanvasRect.z,_VVCanvasRect.w) / 1.25;

	float		m = inHeart(gl_FragCoord.xy, heartSize * _VVCanvasRect.zw, side*topAlpha) ? 1.0 : 0.0;

	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = darkenedBottom;
	returnMe = (m > 0.0) ? top : returnMe;
	return returnMe;
}

vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	float		side = max(_VVCanvasRect.z,_VVCanvasRect.w) / 1.25;

	float		m = inHeart(gl_FragCoord.xy, heartSize * _VVCanvasRect.zw, side*bottomAlpha) ? 1.0 : 0.0;

	vec4		darkenedBottom = vec4(0.0);
	vec4		returnMe = darkenedBottom;
	returnMe = (m > 0.0) ? bottom : returnMe;
	return returnMe;
}

vec4 CompositeTop(vec4 top, float topAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}

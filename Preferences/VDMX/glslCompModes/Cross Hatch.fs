//	adapted from http://transitions.glsl.io/transition/04fd9a7de4012cbb03f6

const vec2 center = vec2(0.5, 0.5);

float quadraticInOut(float t) {
	float p = 2.0 * t * t;
	return t < 0.5 ? p : -p + (4.0 * t) - 1.0;
}

// borrowed from wind.
// https://glsl.io/transition/7de3f4b9482d2b0bf7bb
float rand(vec2 co) {
	return fract(sin(dot(co.xy ,vec2(12.9898,78.233))) * 43758.5453);
}


vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = darkenedBottom;
    float		x = topAlpha * 1.72;
    float		dist = distance(center, p);
    float		r = x - min(rand(vec2(p.y, 0.0)), rand(vec2(0.0, p.x)));
    float		m = dist <= r ? 1.0 : 0.0;
    
    returnMe = mix(darkenedBottom, top, m);  
	return returnMe;
}


vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(0.0);
	vec4		returnMe = darkenedBottom;
    float		x = bottomAlpha * 1.72;
    float		dist = distance(center, p);
    float		r = x - min(rand(vec2(p.y, 0.0)), rand(vec2(0.0, p.x)));
    float		m = dist <= r ? 1.0 : 0.0;
    
    returnMe = mix(darkenedBottom, bottom, m);  
	return returnMe;
}
vec4 CompositeTop(vec4 top, float topAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}

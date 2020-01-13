//	adapted from http://transitions.glsl.io/transition/90000743fedc953f11a4


const vec2 direction = vec2(1.0,0.0);
const vec2 center = vec2(0.5, 0.5);
const float smoothness = 0.5;


vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = darkenedBottom;
	vec2		v = normalize(direction);
	v /= abs(v.x)+abs(v.y);
	float d = v.x * center.x + v.y * center.y;
	float m = smoothstep(-smoothness, 0.0, v.x * p.x + v.y * p.y - (d-0.5+topAlpha*(1.+smoothness)));
	returnMe = mix(top, darkenedBottom, m);
	return returnMe;
}


vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(0.0);
	vec4		returnMe = darkenedBottom;
	vec2		v = normalize(direction);
	v /= abs(v.x)+abs(v.y);
	float d = v.x * center.x + v.y * center.y;
	float m = smoothstep(-smoothness, 0.0, v.x * p.x + v.y * p.y - (d-0.5+bottomAlpha*(1.+smoothness)));
	returnMe = mix(bottom, darkenedBottom, m);
	return returnMe;
}
vec4 CompositeTop(vec4 top, float topAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}

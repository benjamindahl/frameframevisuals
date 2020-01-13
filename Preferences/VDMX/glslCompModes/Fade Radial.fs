//	adapted from http://transitions.glsl.io/transition/ce1d48f0ce00bb379750


#define PI 3.141592653589


vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = darkenedBottom;

	vec2		rp = p*2.-1.;
	float		a = atan(rp.y, rp.x);
	float		pa = topAlpha*PI*2.25-PI*1.25;
	vec4		fromc = darkenedBottom;
	vec4		toc = top;
	
	if(a>pa) {
		returnMe = mix(toc, fromc, smoothstep(0., 1., (a-pa)));
	} else {
		returnMe = toc;
	}
	
	return returnMe;
}

vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(0.0);
	vec4		returnMe = darkenedBottom;

	vec2		rp = p*2.-1.;
	float		a = atan(rp.y, rp.x);
	float		pa = bottomAlpha*PI*2.25-PI*1.25;
	vec4		fromc = darkenedBottom;
	vec4		toc = bottom;
	
	if(a>pa) {
		returnMe = mix(toc, fromc, smoothstep(0., 1., (a-pa)));
	} else {
		returnMe = toc;
	}
	
	return returnMe;
}

vec4 CompositeTop(vec4 top, float topAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}

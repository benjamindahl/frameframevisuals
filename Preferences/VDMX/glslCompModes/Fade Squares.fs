//	based on http://transitions.glsl.io/transition/b6720916aa3f035949bc

//	optional variables
const vec2 direction = vec2(1.0,0.0);
const vec2 center = vec2(0.5, 0.5);
const float smoothness = 2.0;


vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	vec4		returnMe = darkenedBottom;
	vec2 		squares = vec2(floor(_VVCanvasRect.z / 80.0),floor(_VVCanvasRect.w / 80.0));
	squares.x = (squares.x < 4.0) ? floor(_VVCanvasRect.z / 20.0) : squares.x;
	squares.y = (squares.y < 4.0) ? floor(_VVCanvasRect.w / 20.0) : squares.y;
	
	vec2 v = normalize(direction);
	if (v != vec2(0.0))
	v /= abs(v.x)+abs(v.y);
	
	float		d = v.x * center.x + v.y * center.y;
	float		offset = smoothness;
	float		pr = smoothstep(-offset, 0.0, v.x * p.x + v.y * p.y - (d-0.5+topAlpha*(1.+offset)));
	vec2		squarep = fract(p*(squares));
	vec2		squaremin = vec2(pr/2.0);
	vec2		squaremax = vec2(1.0 - pr/2.0);
	float		a = all(lessThan(squaremin, squarep)) && all(lessThan(squarep, squaremax)) ? 1.0 : 0.0;
	
	returnMe = mix(darkenedBottom, top, a);
	return returnMe;
}


vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	vec2		p = gl_FragCoord.xy / _VVCanvasRect.zw;
	vec4		darkenedBottom = vec4(0.0);
	vec4		returnMe = darkenedBottom;
	vec2 		squares = vec2(floor(_VVCanvasRect.z / 80.0),floor(_VVCanvasRect.w / 80.0));
	squares.x = (squares.x < 4.0) ? floor(_VVCanvasRect.z / 20.0) : squares.x;
	squares.y = (squares.y < 4.0) ? floor(_VVCanvasRect.w / 20.0) : squares.y;
	
	vec2 v = normalize(direction);
	if (v != vec2(0.0))
	v /= abs(v.x)+abs(v.y);
	
	float		d = v.x * center.x + v.y * center.y;
	float		offset = smoothness;
	float		pr = smoothstep(-offset, 0.0, v.x * p.x + v.y * p.y - (d-0.5+bottomAlpha*(1.+offset)));
	vec2		squarep = fract(p*(squares));
	vec2		squaremin = vec2(pr/2.0);
	vec2		squaremax = vec2(1.0 - pr/2.0);
	float		a = all(lessThan(squaremin, squarep)) && all(lessThan(squarep, squaremax)) ? 1.0 : 0.0;
	
	returnMe = mix(bottom, darkenedBottom, a);
	return returnMe;
}
vec4 CompositeTop(vec4 top, float topAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}

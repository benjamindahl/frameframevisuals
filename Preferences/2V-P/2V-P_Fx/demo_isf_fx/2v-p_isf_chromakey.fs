/*{
	"DESCRIPTION": "2V-P ISF Chromakey",
	"CREDIT": "Copyright © 2016 2v-p.tv. All rights reserved.",
	"CATEGORIES": [
		"2V-P ISF FX"
	],
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
		{
			"NAME": "maskedImage",
			"TYPE": "image"
		},
        {
            "NAME": "tolerance",
            "TYPE": "float",
            "DEFAULT": 0.3,
            "MIN": 0.0,
            "MAX": 1.0
        },
        {
            "NAME": "xfade",
            "TYPE": "float",
            "DEFAULT": 0.5,
            "MIN": 0.0,
            "MAX": 1.0
        },        
		{
			"NAME": "colortarget",
			"TYPE": "color",
			"DEFAULT": [
				0.0,
				0.0,
				0.0,
				0.0
			]
		},
		{
            "NAME": "invertmask",
            "TYPE": "float",
            "DEFAULT": 0.0,
            "MIN": 0.0,
            "MAX": 1.0
        }
	]
}*/


void main()
{
	// Utils
	vec4 one_third = vec4(0.333333);

    // Init tex0_rgba / tex1_rgba
    vec4 tex0_rgba = IMG_THIS_PIXEL(inputImage);
    vec4 tex1_rgba = IMG_THIS_PIXEL(maskedImage);
    
    // Init source / target
    vec4 source = tex0_rgba;
	vec4 target = colortarget;
	
	// Init alpha components
	source.a = 0.;
	target.a = 0.;
	
	// Distance from target
	vec4 vdelta = abs(source-target);
	
	// Sum vector distance, scaling by a third
	float delta = dot(vdelta,one_third);
	
	// Determine scaling coefficient within xfade range
	float scale = smoothstep(abs(tolerance),abs(tolerance)+abs(xfade),delta);
	
	// Invert if necessary
	float mixamount = mix(scale,1.0-scale,invertmask);
	
	// Blend between sources based on mixamount	
	vec4 result = mix(tex1_rgba,tex0_rgba,vec4(mixamount));
	
    gl_FragColor = result;
       
}

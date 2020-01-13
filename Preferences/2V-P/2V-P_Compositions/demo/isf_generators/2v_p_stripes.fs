/*{
    "DESCRIPTION": "2V-P ISF STRIPES",
	"CREDIT": "Copyright © 2015 2v-p.tv. All rights reserved.",
	"CATEGORIES": [
		"2V-P ISF GENERATOR"
	],
	"INPUTS": [
		{
			"NAME": "width",
			"TYPE": "float",
			"DEFAULT": 0.25
		},
		{
			"NAME": "offset",
			"TYPE": "float",
			"DEFAULT": 0.0
		},
		{
			"NAME": "vertical",
			"TYPE": "bool",
			"DEFAULT": 0.0
		},
		{
			"NAME": "color1",
			"TYPE": "color",
			"DEFAULT": [
				1.0,
				1.0,
				1.0,
				1.0
			]
		},
		{
			"NAME": "color2",
			"TYPE": "color",
			"DEFAULT": [
				0.0,
				0.0,
				0.0,
				1.0
			]
		}
	]
}*/



void main() {
	
	// Check for even or odd line
	vec4 out_color = color2;
	float coord = vv_FragNormCoord[0];

	if (vertical)	{
		coord = vv_FragNormCoord[1];
	}
	if (width == 0.0)	{
		out_color = color1;
	}
	else if(mod(((coord+offset) / width),2.0) < 1.0)	{
		out_color = color1;
	}
	
	gl_FragColor = out_color;
}
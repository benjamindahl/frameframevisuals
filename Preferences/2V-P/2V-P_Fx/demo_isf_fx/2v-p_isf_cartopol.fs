/*{
	"DESCRIPTION": "2V-P ISF CARTOPOL",
	"CREDIT": "Copyright © 2015 2v-p.tv. All rights reserved.",
	"CATEGORIES": [
        "2V-P ISF FX"
	],
	"INPUTS": [
        {
            "NAME": "inputImage",
            "TYPE": "image"
        },
        {
            "NAME": "origin",
            "TYPE": "point2D",
            "DEFAULT": [
                0,
                0
            ]
        },
        {
            "NAME": "scale",
            "TYPE": "point2D",
            "DEFAULT": [
                1.0,
                1.0
            ]
        }
	]
 
 }*/

const float pi=3.1415926;

void main()
{
    vec2 point = abs(mod(vv_FragNormCoord*scale+origin,1.0));
    
    // cartesian to polar conversion
    vec2 dt = 2.*(point-0.5);
    float radius = sqrt(dot(dt,dt)); //hypot
    float theta = atan(dt.y,dt.x)+pi;
    vec2 topol = vec2(radius,theta/(2.*pi));

    //Set the dstPixel
    vec4 dstPixel = IMG_NORM_PIXEL(inputImage, topol);

    gl_FragColor = dstPixel;
}

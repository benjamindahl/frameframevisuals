/*{
    "DESCRIPTION": "2V-P ISF SPIDERWEB",
	"CREDIT": "Copyright © 2015 2v-p.tv. All rights reserved.",
	"CATEGORIES": [
		"2V-P ISF GENERATOR"
	],
	"INPUTS": [
		{
			"NAME": "radialWebs",
			"TYPE": "float",
			"MIN": 1.0,
			"MAX": 50.0,
			"DEFAULT": 10.0
		},
		{
			"NAME": "crossWebs",
			"TYPE": "float",
			"MIN": 1.0,
			"MAX": 50.0,
			"DEFAULT": 10.0
        },
        {
            "NAME": "webDiam",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 1.0,
            "DEFAULT": 0.1
        },
        {
            "NAME": "webCenterX",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 1.0,
            "DEFAULT": 0.5
        },
        {
            "NAME": "webCenterY",
            "TYPE": "float",
            "MIN": 0.0,
            "MAX": 1.0,
            "DEFAULT": 0.5
        },
        {
            "NAME": "webColor",
            "TYPE": "color",
            "DEFAULT": [
                1.0,
                1.0,
                1.0,
                1.0
            ]
        }

	]
}*/


// sqr function
float
sqr(float x)
{
    return x*x;
}

// dist function
float dist (float x, float y)
{
    return (sqrt(sqr(x)+sqr(y)));
}

// gaussian function
float Gaussian(float x, float m, float s)
{
    return (exp2(-sqr(x-m)/sqr(s) * 0.693147));
}


void main()
{
    float s = vv_FragNormCoord[0], t = vv_FragNormCoord[1];
    float TT=t-webCenterY;
    float SS=s-webCenterX;
    
    float rRadius = dist(SS,TT);
    float rAngle=atan(TT, SS);
    
    float rAngleStep=2.0*3.141592/radialWebs;
    float rDist;
    
    float rAccum=0.0;
    float cRadSeg;
    float cCrossSeg;
    float rDiam = webDiam / rRadius * 0.05;

    /* Calculate which radial section its in */
    cRadSeg=floor(rAngle/rAngleStep);
    
    /* Color Radial Webs */
    rAccum+=Gaussian(rAngle, cRadSeg*rAngleStep, rDiam);
    rAccum+=Gaussian(rAngle, mod((cRadSeg+1.0),radialWebs)*rAngleStep, rDiam);
    
    rDist=(SS * cos((cRadSeg+0.5)*rAngleStep) +
           TT * sin((cRadSeg+.5)*rAngleStep));
    
    /* Calculate which cross section its in */
    cCrossSeg=floor(rDist * crossWebs / 2.0);
    
    /* Color Tangential Webs */
    rAccum+=Gaussian(rDist, cCrossSeg/crossWebs * 2.0, rDiam);
    
    
    rAccum+=Gaussian(rDist, (cCrossSeg+1.0)/crossWebs*2.0, rDiam);
    
    
    /* clamp to [0,1] */
    rAccum=clamp(rAccum,0.0,1.0);
    
    gl_FragColor = mix(vec4 (0,0,0,0), webColor, rAccum);
    gl_FragColor[3] = rAccum;
    
}

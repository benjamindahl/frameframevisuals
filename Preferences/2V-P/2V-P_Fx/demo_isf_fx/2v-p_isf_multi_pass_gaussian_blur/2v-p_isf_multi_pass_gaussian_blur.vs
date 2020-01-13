// 2V-P ISF MULTI PASS GAUSSIAN BLUR
// Copyright © 2015 2v-p.tv. All rights reserved.

// Offset to be passed to the fragment shader
varying vec2 texOffsets[3];

// Main Vertex function
void main(void)	{
    
	//	Load the main vertex shader
	vv_vertShaderInit();
	
    // Even Render pass indexs
	if (PASSINDEX==0 || PASSINDEX==2 || PASSINDEX==4 || PASSINDEX==6 || PASSINDEX==8)	{
		float		pixelWidth = 1.0/RENDERSIZE[0]*blurAmount;
		if (PASSINDEX >= 2)
			pixelWidth *= .7;
		else if (PASSINDEX >= 6)
			pixelWidth *= 1.0;
		texOffsets[0] = vv_FragNormCoord;
		texOffsets[1] = clamp(vec2(vv_FragNormCoord[0]-pixelWidth, vv_FragNormCoord[1]),0.0,1.0);
		texOffsets[2] = clamp(vec2(vv_FragNormCoord[0]+pixelWidth, vv_FragNormCoord[1]),0.0,1.0);
	}
    
    // Odd Render pass indexes
	else if (PASSINDEX==1 || PASSINDEX==3 || PASSINDEX==5 || PASSINDEX==7 || PASSINDEX==9)	{
		float		pixelHeight = 1.0/RENDERSIZE[1]*blurAmount;
		if (PASSINDEX >= 3)
			pixelHeight *= .7;
		else if (PASSINDEX >= 6)
			pixelHeight *= 1.0;
		texOffsets[0] = vv_FragNormCoord;
		texOffsets[1] = clamp(vec2(vv_FragNormCoord[0], vv_FragNormCoord[1]-pixelHeight),0.0,1.0);
		texOffsets[2] = clamp(vec2(vv_FragNormCoord[0], vv_FragNormCoord[1]+pixelHeight),0.0,1.0);
	}
}

using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Windows.Forms;

namespace Sort3DPoints
{
    /// <summary>
    /// 四面体类的定义
    /// </summary>
    public class Tetrahedron
    {
        #region 私有变量

            /// <summary>
            /// 顶点
            /// </summary>
            private IPoint nodeTop = null;
            /// <summary>
            /// 底面
            /// </summary>
            private ITinTriangle floor = null;

            // 四面体体积
            private double volume;
            // 四面体的高
            private double height;
            // 四面体的底面面积
            private double area3D;
            // 底面坡度
            private double slope;
            // 顶点到底面的高差
            private double distance;

        #endregion

        #region 构造函数

            /// <summary>
            /// 默认构造函数
            /// </summary>
            public Tetrahedron(){
                // Nothing
            }

            /// <summary>
            /// 顶点底面法构造
            /// </summary>
            /// <param name="tria"></param>
            /// <param name="nodeTop"></param>
            public Tetrahedron(ITinTriangle tria, IPoint nodeTop)
            {
                // 底面
                this.floor = tria;
                // 顶点
                this.nodeTop = nodeTop;
            }

        #endregion

        #region 属性

            /// <summary>
            /// 三倍体积（和体积比减少一次除法运算）
            /// </summary>
            public double Volume
            {
                get
                {
                    this.volume = area3D * height;
                    return volume;
                }
            }

            /// <summary>
            /// 四面体的高H = 高程差绝对值 × 坡度余弦Cos(Slope)
            /// </summary>
            public double Height
            {
                //// 15次乘法，1次除法，一次开平方
                //get
                //{
                //    // 计算平面方程 Ax + By + Cz + D =0;
                //    double A = (node2.Y - node1.Y) * (node3.Z - node1.Z) - (node3.Y - node1.Y) * (node2.Z - node1.Z);
                //    double B = (node2.Z - node1.Z) * (node3.X - node1.X) - (node3.Z - node1.Z) * (node2.X - node1.X);
                //    double C = (node2.X - node1.X) * (node3.Y - node1.Y) - (node3.X - node1.X) * (node2.Y - node1.Y);
                //    double D = -A * node1.X - B * node1.Y - C * node1.Z;
                //    // 使用点到平面的距离公式 H = |Ax1 + By1 + Cz1 +D|/√(A^2 + B^2 + C^2);
                //    this.height = 
                //        Math.Abs(A * nodeTop.X + B * nodeTop.Y + C * nodeTop.Z + D) 
                //        / 
                //        Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2) + Math.Pow(C, 2));
                //    return this.height;
                //}
                get
                {
                    this.height = Distance * Math.Cos(Slope);
                    return height;
                }
            }

            /// <summary>
            /// 底面积
            /// </summary>
            public double Area3D
            {
                get
                {
                    area3D = floor.Area3D;
                    return area3D;
                }
            }

            /// <summary>
            /// 弧度制坡度值
            /// </summary>
            public double Slope
            {
                get
                {
                    // 底面坡度
                    this.slope = floor.SlopeRadians;
                    return slope;
                }
            }

            /// <summary>
            /// 高程差的绝对值
            /// </summary>
            public double Distance
            {
                get
                {
                    this.distance = Math.Abs(
                        (floor.TheTin as ITinSurface2)
                        .GetElevation(nodeTop)
                        -
                        nodeTop.Z
                    );
                    return distance;
                }
            }

        #endregion

        // 废弃方法，计算行列式用
        ///// <summary>
        ///// 给定二维数组，计算行列式的值
        ///// </summary>
        ///// <param name="matrix"></param>
        ///// <returns></returns>
        //public double Determinant(double[][] matrix)
        //{

        //    double dSum = 1, dSign = 1;
        //    double[] matrixChange = new double[matrix.Length];
        //    double[] matrixTemp = new double[matrix.Length];
        //    for (int i = 0; i < matrix.Length; i++)//化成三角阵
        //    {
        //        for (int j = i + 1; j < matrix.Length; j++)
        //        {
        //            if (matrix[i][i] == 0)//如果要乘的那行第一个数等于0，那就把它与下一列对换后继续
        //            {
        //                for (int x = 0; x < matrix.Length; x++)
        //                {
        //                    matrixChange[x] = matrix[i + 1][x];
        //                    matrix[i + 1][x] = matrix[i][x];
        //                    matrix[i][x] = matrixChange[x];
        //                }
        //                dSign = dSign * -1;
        //            }
        //            //if (matrix[j][i] != 0)
        //            matrixTemp[j] = -matrix[j][i] / matrix[i][i];
        //        }
        //        for (int k = i + 1; k < matrix.Length; k++)//将两行乘系数相加，使变成0
        //            for (int m = i; m < matrix.Length; m++)
        //            {
        //                matrix[k][m] = matrixTemp[k] * matrix[i][m] + matrix[k][m];
        //            }

        //    }
        //    for (int q = 0; q < matrix.Length; q++)//三角阵对角线相乘得到结果
        //        dSum = matrix[q][q] * dSum;
        //    dSum = dSum * dSign;
        //    return dSum;
        //}

        ///// <summary>
        ///// 展开法计算行列式
        ///// </summary>
        ///// <param name="matrix"></param>
        ///// <returns></returns>
        //public double DeterminantByElement(double[][] matrix)
        //{

        //    return 0.1;
        //}

        ////double[][] matrix = new double[][]{
        //    new double[] { 1,1,1,1 },
        //    new double[] { 70.15,75.23,0.48,40.14 },
        //    new double[] { 0.2,91.47,79.48,50.11 },
        //    new double[] { 0.4,0.81,0.18,30.15 }
        //};
    }
}

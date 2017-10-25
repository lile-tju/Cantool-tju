#include "stdafx.h"
#include <gtest\gtest.h>
extern int send(int j, int k);

TEST(testCase, test0)
{
	EXPECT_EQ(0, send(0,0));
}

TEST(testCase, test1)
{
	EXPECT_EQ(420, send(0,0));
}

TEST(testCase, test2)
{
	EXPECT_EQ(421, send(0,0));
}
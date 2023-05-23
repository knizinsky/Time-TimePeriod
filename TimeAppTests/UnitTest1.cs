using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeApp;

namespace TimeAppTests
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void Time_CorrectConstruction_Success()
        {
            byte hours = 10;
            byte minutes = 30;
            byte seconds = 0;

            var time = new Time(hours, minutes, seconds);

            Assert.AreEqual(hours, time.Hours);
            Assert.AreEqual(minutes, time.Minutes);
            Assert.AreEqual(seconds, time.Seconds);
        }

        [TestMethod]
        public void Time_InvalidConstruction_ExceptionThrown()
        {
            byte hours = 24;
            byte minutes = 60;
            byte seconds = 60;

            Assert.ThrowsException<ArgumentException>(() => new Time(hours, minutes, seconds));
        }

        [TestMethod]
        public void Time_TimeToString_CorrectFormat()
        {
            byte hours = 9;
            byte minutes = 5;
            byte seconds = 15;
            string expected = "09:05:15";

            var time = new Time(hours, minutes, seconds);
            var result = time.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Time_StringToTime_CorrectConstruction()
        {
            string timeString = "15:30:45";
            byte expectedHours = 15;
            byte expectedMinutes = 30;
            byte expectedSeconds = 45;

            var time = new Time(timeString);

            Assert.AreEqual(expectedHours, time.Hours);
            Assert.AreEqual(expectedMinutes, time.Minutes);
            Assert.AreEqual(expectedSeconds, time.Seconds);
        }

        [TestMethod]
        public void Time_InvalidStringToTime_ExceptionThrown()
        {
            string timeString = "15:30";

            Assert.ThrowsException<ArgumentException>(() => new Time(timeString));
        }

        [TestMethod]
        public void Time_EqualityOperator_CorrectComparison()
        {
            var time1 = new Time(10, 30, 0);
            var time2 = new Time(10, 30, 0);
            var time3 = new Time(10, 20, 0);

            Assert.IsTrue(time1 == time2);
            Assert.IsFalse(time1 == time3);
        }

        [TestMethod]
        public void Time_InequalityOperator_CorrectComparison()
        {
            var time1 = new Time(10, 30, 0);
            var time2 = new Time(10, 30, 0);
            var time3 = new Time(10, 20, 0);

            Assert.IsFalse(time1 != time2);
            Assert.IsTrue(time1 != time3);
        }

        [TestMethod]
        public void Time_LessThanOperator_CorrectComparison()
        {
            var time1 = new Time(10, 30, 0);
            var time2 = new Time(11, 0, 0);
            var time3 = new Time(10, 30, 1);

            Assert.IsTrue(time1 < time2);
            Assert.IsTrue(time1 < time3);
            Assert.IsFalse(time2 < time1);
        }

        [TestMethod]
        public void Time_LessThanOrEqualOperator_CorrectComparison()
        {
            var time1 = new Time(10, 30, 0);
            var time2 = new Time(11, 0, 0);
            var time3 = new Time(10, 30, 1);

            Assert.IsTrue(time1 <= time2);
            Assert.IsTrue(time1 <= time3);
            Assert.IsTrue(time1 <= time1);
            Assert.IsFalse(time2 <= time1);
        }

        [TestMethod]
        public void Time_GreaterThanOperator_CorrectComparison()
        {
            var time1 = new Time(10, 30, 0);
            var time2 = new Time(11, 0, 0);
            var time3 = new Time(10, 30, 1);

            Assert.IsFalse(time1 > time2);
            Assert.IsFalse(time1 > time3);
            Assert.IsTrue(time2 > time1);
        }

        [TestMethod]
        public void Time_GreaterThanOrEqualOperator_CorrectComparison()
        {
            var time1 = new Time(10, 30, 0);
            var time2 = new Time(11, 0, 0);
            var time3 = new Time(10, 30, 1);

            Assert.IsFalse(time1 >= time2);
            Assert.IsFalse(time1 >= time3);
            Assert.IsTrue(time1 >= time1);
            Assert.IsTrue(time2 >= time1);
        }

        [TestMethod]
        public void Time_EqualsMethod_CorrectComparison()
        {
            var time1 = new Time(10, 30, 0);
            var time2 = new Time(10, 30, 0);
            var time3 = new Time(10, 20, 0);

            Assert.IsTrue(time1.Equals(time2));
            Assert.IsFalse(time1.Equals(time3));
            Assert.IsFalse(time1.Equals(null));
            Assert.IsFalse(time1.Equals("string"));
        }

        [TestMethod]
        public void Time_GetHashCode_CorrectHashCode()
        {
            var time1 = new Time(10, 30, 0);
            var time2 = new Time(10, 30, 0);
            var time3 = new Time(10, 20, 0);

            Assert.AreEqual(time1.GetHashCode(), time2.GetHashCode());
            Assert.AreNotEqual(time1.GetHashCode(), time3.GetHashCode());
        }

        [TestMethod]
        public void Time_CompareToMethod_CorrectComparison()
        {
            var time1 = new Time(10, 30, 0);
            var time2 = new Time(11, 0, 0);
            var time3 = new Time(10, 30, 1);

            Assert.AreEqual(0, time1.CompareTo(time1));
            Assert.AreEqual(-1, time1.CompareTo(time2));
            Assert.AreEqual(1, time2.CompareTo(time1));
            Assert.AreEqual(-1, time1.CompareTo(time3));
            Assert.AreEqual(1, time3.CompareTo(time1));
        }

        [TestMethod]
        public void Time_CorrectConstruction_ValuesWithinRange1()
        {
            byte hours = 10;
            byte minutes = 30;
            byte seconds = 45;

            var time = new Time(hours, minutes, seconds);

            Assert.IsTrue(time.Hours >= 0 && time.Hours <= 23);
            Assert.IsTrue(time.Minutes >= 0 && time.Minutes <= 59);
            Assert.IsTrue(time.Seconds >= 0 && time.Seconds <= 59);
        }
    }

    [TestClass]
    public class TimePeriodTests
    {
        [TestMethod]
        public void ToString_ShouldReturnCorrectStringRepresentation()
        {
            TimePeriod timePeriod = new TimePeriod(2, 30, 45);
            string expectedString = "2:30:45";

            string actualString = timePeriod.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void Equals_TwoEqualTimePeriods_ReturnsTrue()
        {
            var timePeriod1 = new TimePeriod(1, 30, 0);
            var timePeriod2 = new TimePeriod(1, 30, 0);

            var result = timePeriod1.Equals(timePeriod2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_TwoDifferentTimePeriods_ReturnsFalse()
        {
            var timePeriod1 = new TimePeriod(1, 30, 0);
            var timePeriod2 = new TimePeriod(2, 0, 0);

            var result = timePeriod1.Equals(timePeriod2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OperatorEquals_TwoEqualTimePeriods_ReturnsTrue()
        {
            var timePeriod1 = new TimePeriod(1, 30, 0);
            var timePeriod2 = new TimePeriod(1, 30, 0);

            var result = timePeriod1 == timePeriod2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorEquals_TwoDifferentTimePeriods_ReturnsFalse()
        {
            var timePeriod1 = new TimePeriod(1, 30, 0);
            var timePeriod2 = new TimePeriod(2, 0, 0);

            var result = timePeriod1 == timePeriod2;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OperatorNotEquals_TwoEqualTimePeriods_ReturnsFalse()
        {
            var timePeriod1 = new TimePeriod(1, 30, 0);
            var timePeriod2 = new TimePeriod(1, 30, 0);

            var result = timePeriod1 != timePeriod2;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OperatorNotEquals_TwoDifferentTimePeriods_ReturnsTrue()
        {
            var timePeriod1 = new TimePeriod(1, 30, 0);
            var timePeriod2 = new TimePeriod(2, 0, 0);

            var result = timePeriod1 != timePeriod2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CompareTo_SmallerTimePeriod_ReturnsPositiveValue()
        {
            TimePeriod smallerTimePeriod = new TimePeriod(1, 30, 0);
            TimePeriod largerTimePeriod = new TimePeriod(2, 0, 0);

            int result = smallerTimePeriod.CompareTo(largerTimePeriod);

            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareTo_LargerTimePeriod_ReturnsNegativeValue()
        {
            TimePeriod smallerTimePeriod = new TimePeriod(1, 30, 0);
            TimePeriod largerTimePeriod = new TimePeriod(2, 0, 0);

            int result = largerTimePeriod.CompareTo(smallerTimePeriod);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareTo_EqualTimePeriod_ReturnsZero()
        {
            TimePeriod timePeriod1 = new TimePeriod(1, 30, 0);
            TimePeriod timePeriod2 = new TimePeriod(1, 30, 0);

            int result = timePeriod1.CompareTo(timePeriod2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_EqualTimePeriods_ReturnsTrue()
        {
            TimePeriod timePeriod1 = new TimePeriod(1, 30, 0);
            TimePeriod timePeriod2 = new TimePeriod(1, 30, 0);

            bool result = timePeriod1.Equals(timePeriod2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_DifferentTimePeriods_ReturnsFalse()
        {
            TimePeriod timePeriod1 = new TimePeriod(1, 30, 0);
            TimePeriod timePeriod2 = new TimePeriod(2, 0, 0);

            bool result = timePeriod1.Equals(timePeriod2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Operator_Equality_EqualTimePeriods_ReturnsTrue()
        {
            TimePeriod timePeriod1 = new TimePeriod(1, 30, 0);
            TimePeriod timePeriod2 = new TimePeriod(1, 30, 0);

            bool result = timePeriod1 == timePeriod2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Operator_Inequality_DifferentTimePeriods_ReturnsTrue()
        {
            TimePeriod timePeriod1 = new TimePeriod(1, 30, 0);
            TimePeriod timePeriod2 = new TimePeriod(2, 0, 0);

            bool result = timePeriod1 != timePeriod2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Operator_LessThan_SmallerTimePeriod_ReturnsTrue()
        {
            TimePeriod smallerTimePeriod = new TimePeriod(1, 30, 0);
            TimePeriod largerTimePeriod = new TimePeriod(2, 0, 0);

            bool result = smallerTimePeriod < largerTimePeriod;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Operator_LessThanOrEqual_SmallerTimePeriod_ReturnsTrue()
        {
            TimePeriod smallerTimePeriod = new TimePeriod(1, 30, 0);
            TimePeriod largerTimePeriod = new TimePeriod(2, 0, 0);

            bool result = smallerTimePeriod <= largerTimePeriod;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Operator_GreaterThan_LargerTimePeriod_ReturnsTrue()
        {
            TimePeriod smallerTimePeriod = new TimePeriod(1, 30, 0);
            TimePeriod largerTimePeriod = new TimePeriod(2, 0, 0);

            bool result = largerTimePeriod > smallerTimePeriod;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Operator_GreaterThanOrEqual_LargerTimePeriod_ReturnsTrue()
        {
            TimePeriod smallerTimePeriod = new TimePeriod(1, 30, 0);
            TimePeriod largerTimePeriod = new TimePeriod(2, 0, 0);

            bool result = largerTimePeriod >= smallerTimePeriod;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Operator_Addition_ReturnsCorrectTimePeriod()
        {
            TimePeriod timePeriod1 = new TimePeriod(1, 30, 0);
            TimePeriod timePeriod2 = new TimePeriod(0, 45, 0);

            TimePeriod result = timePeriod1 + timePeriod2;

            Assert.AreEqual("2:15:00", result.ToString());
        }

        [TestMethod]
        public void Operator_Subtraction_ReturnsCorrectTimePeriod()
        {
            TimePeriod timePeriod1 = new TimePeriod(2, 0, 0);
            TimePeriod timePeriod2 = new TimePeriod(1, 30, 0);

            TimePeriod result = timePeriod1 - timePeriod2;

            Assert.AreEqual(30, result.TotalSeconds/60);
        }
    }
}

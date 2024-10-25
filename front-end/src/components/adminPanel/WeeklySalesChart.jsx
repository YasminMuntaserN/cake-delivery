import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';
import useSales from './useSales';

function WeeklySalesChart() {
  const { data } = useSales();
  console.log(data );
  const daysOfWeek = ["Monday", 'Tuesday', "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
  
  const dataByDay = data.reduce((acc, current) => {
      acc[current.day] = current.sales;
      return acc;
  }, {});
  
  console.log(dataByDay);
  const SalesData = daysOfWeek.map(day => ({
      day,
      sales: dataByDay[day] || 0 
  }));
  
  console.log(SalesData);
  return (
    <ResponsiveContainer width="100%" height={600}>
    <BarChart
        data={SalesData}
        margin={{ top: 20, right: 20, left: 20, bottom: 5 }}
    >
        <CartesianGrid strokeDasharray="3 3" />
        <XAxis dataKey="day" />
        <YAxis />
        <Tooltip />
        <Bar dataKey="sales" fill="#cf8999" />
    </BarChart>
</ResponsiveContainer>
);
}

export default WeeklySalesChart

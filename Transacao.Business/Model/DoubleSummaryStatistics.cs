using Transacao.Business.Model;

namespace Transacao.Business.Model;

public class DoubleSummaryStatistics
{
    public int Count { get; private set; }
    public double Sum { get; private set; }
    public double Min { get; private set; }
    public double Max { get; private set; }
    public double Average => Count > 0 ? Sum / Count : 0;

    public DoubleSummaryStatistics(IEnumerable<TransacaoDTO> values)
    {
        var intervaloDeTempo = DateTime.Now.AddSeconds(-60);
        var valuesFiltered = values
            .Where(v => intervaloDeTempo <= v.dataTransacao)
            .Select(v => v.valor).ToList();
        if (valuesFiltered == null || !valuesFiltered.Any())
        {
            Count = 0;
            Sum = 0;
            Min = 0;
            Max = 0;
            return;
        }
        
        Count = valuesFiltered.Count();
        Sum = valuesFiltered.Sum();
        Min = valuesFiltered.Min();
        Max = valuesFiltered.Max();
    }

    public override string ToString()
    {
        return $"Count: {Count}, Sum: {Sum}, Min: {Min}, Max: {Max}, Average: {Average}";
    }
}
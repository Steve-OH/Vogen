﻿namespace Vogen.IntegrationTests.TestTypes.ClassVos;

[ValueObject(conversions: Conversions.None, underlyingType: typeof(long))]
public partial class LongVo { }

[ValueObject(conversions: Conversions.None, underlyingType: typeof(long))]
public partial class NoConverterLongVo { }

[ValueObject(conversions: Conversions.TypeConverter, underlyingType: typeof(long))]
public partial class NoJsonLongVo { }

[ValueObject(conversions: Conversions.NewtonsoftJson, underlyingType: typeof(long))]
public partial class NewtonsoftJsonLongVo { }

[ValueObject(conversions: Conversions.SystemTextJson, underlyingType: typeof(long))]
public partial class SystemTextJsonLongVo { }

[ValueObject(conversions: Conversions.ServiceStackDotText, underlyingType: typeof(long))]
public partial class SsdtLongVo { }

[ValueObject(conversions: Conversions.SystemTextJson, underlyingType: typeof(long), customizations: Customizations.TreatNumberAsStringInSystemTextJson)]
public partial class SystemTextJsonLongVo_Treating_numbers_as_string { }

[ValueObject(conversions: Conversions.NewtonsoftJson | Conversions.SystemTextJson, underlyingType: typeof(long))]
public partial class BothJsonLongVo { }

[ValueObject(conversions: Conversions.EfCoreValueConverter, underlyingType: typeof(long))]
public partial class EfCoreLongVo { }

[ValueObject(conversions: Conversions.DapperTypeHandler, underlyingType: typeof(long))]
public partial class DapperLongVo { }

[ValueObject(conversions: Conversions.LinqToDbValueConverter, underlyingType: typeof(long))]
public partial class LinqToDbLongVo { }
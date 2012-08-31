﻿' Copyright 2010-2012 10gen Inc.
'*
'* Licensed under the Apache License, Version 2.0 (the "License");
'* you may not use this file except in compliance with the License.
'* You may obtain a copy of the License at
'*
'* http://www.apache.org/licenses/LICENSE-2.0
'*
'* Unless required by applicable law or agreed to in writing, software
'* distributed under the License is distributed on an "AS IS" BASIS,
'* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'* See the License for the specific language governing permissions and
'* limitations under the License.
'


Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports NUnit.Framework

Imports MongoDB.Bson
Imports MongoDB.Driver
Imports MongoDB.Driver.Linq

Namespace MongoDB.DriverUnitTests.Jira

    <TestFixture()>
    Public Class CSharp542

        Public Class Test
            Public Id As ObjectId

            Public MyNullableInt As Nullable(Of Integer)
        End Class

        <Test()>
        Public Sub TestNullableComparison()

            Dim server = MongoServer.Create()
            Dim db = server.GetDatabase("test")
            Dim col = db.GetCollection(Of Test)("foos")

            Dim query = col.AsQueryable.Where(Function(p) p.MyNullableInt = 3)

            Dim list = query.ToList()

        End Sub
    End Class

End Namespace

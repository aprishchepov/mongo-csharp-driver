﻿/* Copyright 2010-2012 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using NUnit.Framework;

using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.DriverUnitTests.Jira.CSharp230
{
    [TestFixture]
    public class CSharp230Tests
    {
        private MongoServer _server;
        private MongoDatabase _database;
        private MongoCollection<BsonDocument> _collection;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _server = Configuration.TestServer;
            _database = Configuration.TestDatabase;
            _collection = Configuration.TestCollection;
        }

        [Test]
        public void TestEnsureIndexAfterDropCollection()
        {
            if (_collection.Exists())
            {
                _collection.Drop();
            }
            _server.ResetIndexCache();

            Assert.IsFalse(_collection.IndexExists("x"));
            _collection.EnsureIndex("x");
            Assert.IsTrue(_collection.IndexExists("x"));

            _collection.Drop();
            Assert.IsFalse(_collection.IndexExists("x"));
            _collection.EnsureIndex("x");
            Assert.IsTrue(_collection.IndexExists("x"));
        }
    }
}
